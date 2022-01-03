using icok1.Service.Contract;
using icok1.Service.Implementation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace icok1.Service
{
    public static class DependencyInjection
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            // or you can use assembly in Extension method in Infra layer with below command
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient<IEmailService, MailService>();
        }
    }
}

