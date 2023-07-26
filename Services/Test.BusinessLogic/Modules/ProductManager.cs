using AutoMapper;
using Test.BusinessLogic.Interfaces;
using Test.BusinessLogic.Models;
using Test.Core.Data;

namespace Test.BusinessLogic
{
    public class ProductManager : DataManagerBase<Product, Context.Product, int, Context.testContext>, IProductManager
    {
        public ProductManager(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider, mapper)
        {
        }
    }
}