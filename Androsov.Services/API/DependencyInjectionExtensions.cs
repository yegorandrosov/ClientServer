using Androsov.Services.API.Implementations;
using Androsov.Services.API.Interfaces;
using Androsov.Services.API.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Androsov.Services.API
{
    public static class DependencyInjectionExtensions
    {
        public static void ConfigureAPI(this IServiceCollection services, 
            Func<IServiceProvider, BasicApiClientAuthentication> getCredentialsFactory,
            ServiceLifetime lifetime)
        {
            services.AddHttpClient("api")
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                    };
                });

            services.Add(new ServiceDescriptor(typeof(BasicApiClientAuthentication), getCredentialsFactory, lifetime));
            services.Add(new ServiceDescriptor(typeof(IApiClient), typeof(ApiClient), lifetime));
            services.Add(new ServiceDescriptor(typeof(IUsersApiClientFactory), typeof(UsersApiClientFactory), lifetime));

        }
    }
}
