using Androsov.Services.API.Implementations;
using Androsov.Services.API.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Androsov.Services.API
{
    public static class DependencyInjectionExtensions
    {
        public static void ConfigureAPI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IApiClient, ApiClient>();
            serviceCollection.AddScoped<IMessageApiClient, MessageApiClient>();
        }
    }
}
