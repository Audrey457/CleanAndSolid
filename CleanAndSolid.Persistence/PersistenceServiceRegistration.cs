using CleanAndSolid.Application.Contracts.Persistance;
using CleanAndSolid.Persistence.DatabaseContext;
using CleanAndSolid.Persistence.DatabaseContext.Repositories;
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
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            return services;
        }

    }
}