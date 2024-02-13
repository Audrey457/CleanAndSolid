

using CleanAndSolid.Application.Contracts.Email;
using CleanAndSolid.Application.Models.Email;
using CleanAndSolid.Infrastructure.EmailService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanAndSolid.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            //Transient car on veut une nouvelle instance de EmailSender à chaque fois qu'on l'utilise.
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
