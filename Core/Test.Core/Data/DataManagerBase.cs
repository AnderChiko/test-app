using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Test.Core.Interfaces.Data;
using Test.Core.Models.Data;

namespace Test.Core.Data
{
    /// <summary>
    /// Entity framework base class that handles create, read, update, delete operations against a SQL database using Entity Framework
    /// </summary>
    /// <typeparam name="TModel">Model passed in</typeparam>
    /// <typeparam name="TKey">Type of database primary key</typeparam>
    /// <typeparam name="TDbContext">Database context passed in</typeparam>
    public abstract class DataManagerBase<TModel, TContextModel, TKey, TDbContext>
        : ICrudManager<TModel, TKey>
        where TDbContext : DbContext
        where TModel : class, new()
        where TContextModel : class, new()
    {
        protected readonly IServiceProvider _serviceProvider;
        protected IMapper _mapper;
        protected virtual TDbContext GetDbContext()
        {
            return _serviceProvider.GetRequiredService<TDbContext>();
        }

        protected DataManagerBase(IServiceProvider serviceProvider, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
            _mapper = mapper;
         }

        /// <summary>
        /// Create an entry.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public virtual async Task<DataResult<TModel>> Create(TModel entry)
        {
            using (var dbContext = GetDbContext())
            {
               var mappedEntry = _mapper.Map<TContextModel>(entry);

                dbContext.Entry(mappedEntry).State = EntityState.Added;
                var contextResult = dbContext.Add(mappedEntry);
                await dbContext.SaveChangesAsync();

                return new DataResult<TModel>(_mapper.Map<TModel>(contextResult.Entity));
            }
        }

        /// <summary>
        /// Update an entry.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public virtual async Task<DataResult<TModel>> Update(TModel entry)
        {

            using (var dbContext = GetDbContext())
            {
                dbContext.Entry(entry).State = EntityState.Modified;
                var contextResult = dbContext.Update(entry);
                await dbContext.SaveChangesAsync();

                return new DataResult<TModel>( contextResult.Entity);
            }
        }

        /// <summary>
        /// Delete an entry. Hard delete.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<Result> Delete(TKey id)
        {
            using (var dbContext = GetDbContext())
            {
                var dbSet = dbContext.Set<TModel>();
                var entry = await dbSet.FindAsync(id);
                dbContext.Entry(entry).State = EntityState.Deleted;

                await dbContext.SaveChangesAsync();

                return new Result(Status.Success)
                {
                    Message = "Successfully Deleted",
                    StatusCode = "200",
                };
            }
        }

        /// <summary>
        /// Create range: caters for creating a list of entries.
        /// </summary>
        /// <param name="entry">Entry to update which is a List of TModel</param>
        /// <returns>Returns a data result of the entry</returns>
        public virtual async Task<DataResult<List<TModel>>> Create(List<TModel> entries)
        {

            using (var dbContext = GetDbContext())
            {
                var dbSet = dbContext.Set<TModel>();
                dbSet.AddRange(entries);

                await dbContext.SaveChangesAsync();

                var result = new DataResult<List<TModel>>( entries);

                return result;
            }
        }

        /// <summary>
        /// Update range: caters for updating a list of entries.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public virtual async Task<DataResult<List<TModel>>> Update(List<TModel> entries)
        {

            using (var dbContext = GetDbContext())
            {
                var dbSet = dbContext.Set<TModel>();
                dbSet.UpdateRange(entries);

                var result = await dbContext.SaveChangesAsync();

                return new DataResult<List<TModel>>( entries);
            }
        }

        /// <summary>
        /// Delete a range. Caters for deleting a list of entry.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public virtual async Task<Result> Delete(List<TModel> entry)
        {
            using (var dbContext = GetDbContext())
            {
                var dbSet = dbContext.Set<TModel>();
                dbSet.RemoveRange(entry);

                await dbContext.SaveChangesAsync();

                return new Result(Status.Success)
                {
                    Message = "Successfully Deleted",
                    StatusCode = "200",
                };
            }
        }

        /// <summary>
        /// Get by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<DataResult<TModel>> Get(TKey id)
        {
            using (var dbContext = GetDbContext())
            {
                var dbSet = dbContext.Set<TModel>();

                return new DataResult<TModel>( await dbSet.FindAsync(id));
            }
        }

        private TModel SetValue(TModel entry, string propertyName, object value)
        {
            var propertyInfo = entry.GetType().GetProperty(propertyName);

            if (propertyInfo is null)
                return entry;

            var type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;

            if (propertyInfo.PropertyType.IsEnum)
            {
                propertyInfo.SetValue(entry, Enum.Parse(propertyInfo.PropertyType, value.ToString()!));
            }
            else
            {
                var safeValue = (value == null) ? null : Convert.ChangeType(value, type);
                propertyInfo.SetValue(entry, safeValue, null);
            }

            return entry;
        }

    }
}
