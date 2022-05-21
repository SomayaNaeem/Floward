using Microsoft.Extensions.DependencyInjection;

namespace Notification.Infrastructure.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //services.AddScoped<IEmailService, EmailService>();
            return services;
        }
    }
}