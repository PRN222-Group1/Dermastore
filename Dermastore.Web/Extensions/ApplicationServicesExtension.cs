using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Infrastructure.Data;
using Dermastore.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Dermastore.Application.Extensions;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity;

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

            return services;
        }
    }
}
