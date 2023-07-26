using AutoMapper;
using System.Runtime.InteropServices;
using Test.BusinessLogic.Interfaces;
using Test.BusinessLogic.Models;
using Test.Core.Data;
using Test.Core.Models.Data;

namespace Test.BusinessLogic
{
    public class OrderManager : DataManagerBase<Order, Context.Order, int, Context.testContext>, IOrderManager
    {
        public OrderManager(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider, mapper)
        {
        }

        /// <summary>
        /// Create an entry.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public override async Task<DataResult<Order>> Create(Order entry)
        {
            return await base.Create(entry);
        }
    }
}