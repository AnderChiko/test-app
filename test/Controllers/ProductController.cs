
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test.BusinessLogic;
using Test.BusinessLogic.Interfaces;
using Test.BusinessLogic.Models;
using Test.Core.Web;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CrudControllerBase<ProductController, IProductManager, Product, int>
    {
        public ProductController(ProductManager manager, ILogger<ProductController> loggingManager) :
            base(manager, loggingManager)
        {
        }
    }
}