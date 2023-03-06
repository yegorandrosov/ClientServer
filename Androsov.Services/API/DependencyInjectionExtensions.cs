using Androsov.Services.API.Implementations;
using Androsov.Services.API.Interfaces;
using Androsov.Services.API.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Androsov.Services.API
{
    public static class DependencyInjectionExtensions
    {
        public static void ConfigureAPI(this IServiceCollection services, Func<IServiceProvider, BasicApiClientAuthentication> getCredentials)
        {
            services.AddHttpClient("api")
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                    };
                });

            services.AddScoped<IApiClient, ApiClient>();
            services.AddScoped<IUsersApiClientFactory, UsersApiClientFactory>();

            services.AddTransient<BasicApiClientAuthentication>(sp => getCredentials(sp));
        }
    }
}
