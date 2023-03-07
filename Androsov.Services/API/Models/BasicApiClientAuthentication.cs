using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Androsov.Services.API.Models
{
    public class BasicApiClientAuthentication
    {
        public BasicApiClientAuthentication(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Password { get; set; }
        public string Username { get; set; }

        public static Func<IServiceProvider, BasicApiClientAuthentication> FromAppSettings => sp =>
        {
            var config = sp.GetRequiredService<IConfiguration>();

            var username = config.GetValue<string>("API:Username");
            var password = config.GetValue<string>("API:Password");

            if (username == null || password == null)
            {
                throw new Exception("API not initialized");
            }

            return new BasicApiClientAuthentication(username, password);
        };
    }
}
