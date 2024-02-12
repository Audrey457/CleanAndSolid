using CleanAndSolid.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanAndSolid.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CleanAndSolidDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CleanAndSolidDbConnectionString"));
            });
            return services;
        }

    }
}
()