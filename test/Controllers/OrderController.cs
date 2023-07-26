
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
    public class OrderController : CrudControllerBase<OrderController, IOrderManager, Order, int>
    {
        public OrderController(OrderManager manager, ILogger<OrderController> loggingManager) :
            base(manager, loggingManager)
        {
        }
    }
}