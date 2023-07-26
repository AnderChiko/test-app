using AutoMapper;
using Test.BusinessLogic.Interfaces;
using Test.BusinessLogic.Models;
using Test.Core.Data;

namespace Test.BusinessLogic
{
    public class UserManager : DataManagerBase<User, Context.User, int, Context.testContext>, IUserManager
    {
        public UserManager(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider, mapper)
        {
        }
    }
}