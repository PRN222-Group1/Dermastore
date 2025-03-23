using Dermastore.Application.Extensions;
using Dermastore.Domain.Interfaces;
using Dermastore.Infrastructure.Data;
using Dermastore.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Dermastore.Web.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            // Add services to the container.
            services.AddRazorComponents();

            services.AddQuickGridEntityFrameworkAdapter();

            services.AddDatabaseDeveloperPageExceptionFilter();

            // Add MediatR
            services.AddMediatR(typeof(ApplicationServicesExtension).Assembly);

            // Registers the database context with the DI container
            services.AddDbContext<DermastoreContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Scoped);

            // Registers app services
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
