﻿using Microsoft.Extensions.DependencyInjection;

namespace BlazorRepository
{
    public static class DependenceInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUsersService, UserService>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}