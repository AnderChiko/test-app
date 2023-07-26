using Test.BusinessLogic.Models;
using Test.Core.Interfaces.Data;

namespace Test.BusinessLogic.Interfaces
{
    public interface IProductManager : ICrudManager<Product, int>
    {
    }
}