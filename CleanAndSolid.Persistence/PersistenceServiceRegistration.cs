using Microsoft.Extensions.DependencyInjection;

namespace CleanAndSolid.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            return services;
        }

    }
}
