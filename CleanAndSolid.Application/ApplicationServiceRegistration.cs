using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanAndSolid.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationsServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
