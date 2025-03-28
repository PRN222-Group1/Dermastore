using Dermastore.Application.Commands.Vnpays;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Interfaces;
using Dermastore.Infrastructure.Data;
using Dermastore.Infrastructure.Services;
using Dermastore.Web.Components;
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
            services.AddRazorComponents().AddInteractiveServerComponents();

            services.AddQuickGridEntityFrameworkAdapter();

            services.AddDatabaseDeveloperPageExceptionFilter();

            // Add MediatR
            services.AddMediatR();

            // Registers the database context with the DI container
            services.AddDbContext<DermastoreContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            // Registers app services
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IVnpayService, VnpayService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}