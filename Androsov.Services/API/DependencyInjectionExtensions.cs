using Androsov.Services.API.Implementations;
using Androsov.Services.API.Interfaces;
using Androsov.Services.API.Models;
using Androsov.Services.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Androsov.Services.API
{
    public static class DependencyInjectionExtensions
    {
        public static void ConfigureAPI(this IServiceCollection services, 
            Func<IServiceProvider, BasicApiClientAuthentication> getCredentialsFactory,
            ServiceLifetime lifetime)
        {
            services.AddHttpClient("api", (sp, client) =>
                {
                    var configuration = sp.GetRequiredService<IConfiguration>();
                    var url = configuration.GetValue<string>("API:Url");

                    client.BaseAddress = new Uri(url!);
                })
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler
                    {
                        // TODO: accept certificate of one container in another
                        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                    };
                });

            services.Add(new ServiceDescriptor(typeof(BasicApiClientAuthentication), getCredentialsFactory, lifetime));
            services.Add(new ServiceDescriptor(typeof(IApiClient), typeof(ApiClient), lifetime));
            services.Add(new ServiceDescriptor(typeof(IUsersApiClientFactory), typeof(UsersApiClientFactory), lifetime));
            services.Add(new ServiceDescriptor(typeof(IAuthenticatedApiHttpClientFactory), typeof(AuthenticatedApiHttpClientFactory), lifetime));
            services.Add(new ServiceDescriptor(typeof(IUsersApiHttpClientFactory), typeof(UsersApiHttpClientFactory), lifetime));
            services.Add(new ServiceDescriptor(typeof(IAccountApiClient), typeof(AccountApiClient), lifetime));
            services.Add(new ServiceDescriptor(typeof(ITokenProvider), typeof(TokenProvider), lifetime));
            services.Add(new ServiceDescriptor(typeof(IUsersApiClientCollection), typeof(UsersApiClientCollection), lifetime));
            

            services.AddSingleton<ITokenValidator, ValidateByIssuingDateTokenValidator>();
        }
    }
}
