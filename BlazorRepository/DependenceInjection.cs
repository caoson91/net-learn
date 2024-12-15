using BlazorRepository.Repository;
using BlazorRepository.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorRepository
{
    public static class DependenceInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUsersService, UserService>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
