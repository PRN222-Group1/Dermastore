using Dermastore.Application.Extensions;
using Dermastore.Domain.Interfaces;
using Dermastore.Infrastructure.Data;
using Dermastore.Infrastructure.Services;
using Dermastore.Web.Containers;
using Dermastore.Web.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using VNPAY.NET;

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
            }, ServiceLifetime.Transient);

            // Registers app services
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddSingleton<ICartService, CartService>();
            services.AddSingleton<CartStateContainer>();
            services.AddSingleton<IVnpay, Vnpay>();
            services.AddScoped<IVnpayService, VnpayService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddSingleton<AuthStateProvider>();

            services.AddSingleton<IConnectionMultiplexer>(redisConfig =>
            {
                var connString = config.GetConnectionString("Redis")
                    ?? throw new Exception("Cannot get redis connection string");
                var configuration = ConfigurationOptions.Parse(connString, true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            return services;
        }
    }
}