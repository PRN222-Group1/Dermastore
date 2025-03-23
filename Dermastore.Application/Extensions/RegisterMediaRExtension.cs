using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dermastore.Application.Extensions
{
    public static class RegisterMediaRExtension
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services, Assembly assembly)
        {
            services.AddMediatR(
                config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            return services;
        }
    }
}
