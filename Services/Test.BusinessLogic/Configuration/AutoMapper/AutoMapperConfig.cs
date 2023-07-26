using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BusinessLogic.Configuration;
using Test.BusinessLogic.Configuration.AutoMapper;

namespace Test.Core.Configuration
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection ConfigureBusinessLogicAutomapper(this IServiceCollection services)
        {
            services.ConfigureAutoMapper(new Profile[]
            {
                new ServiceContextMapperProfile(),
            });
            return services;
        }
    }
}