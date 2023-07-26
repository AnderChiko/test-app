﻿using Microsoft.Extensions.DependencyInjection;
using Test.BusinessLogic.Interfaces;

namespace Test.BusinessLogic
{
    public static class IoC
    {
        /// <summary>
        /// Method to register the Core dependencies.
        /// 
        /// Transient: A new instance of the type is used every time the type is requested.
        /// 
        /// Scoped: A new instance of the type is created the first time it’s requested within
        ///			a given HTTP request, and then re - used for all subsequent types resolved
        ///			during that HTTP request.
        ///			
        /// Singleton: A single instance of the type is created once, and used by all subsequent
        ///			requests for that type.
        ///			
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBusinessLogicIOC(this IServiceCollection services)
        {
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IUserManager, UserManager>();

            return services;
        }
    }
}