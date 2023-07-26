
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
    public class UserController : CrudControllerBase<UserController, IUserManager,User, int>
    {
        public UserController(UserManager manager, ILogger<UserController> loggingManager) :
            base(manager, loggingManager)
        {
        }
    }
}
