using Androsov.DataAccess.Cache;
using Androsov.DataAccess.Entities;
using Androsov.DataAccess.Interfaces;
using Androsov.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Androsov.DataAccess
{
    public static class DependencyInjectionExtensions
    {
        public static void ConfigureSqlServerAndIdentity(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString, x => x.EnableRetryOnFailure());
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IDatabaseInitializer, ApplicationDatabaseInitializer>();
        }

        public static void ConfigureCacheServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CacheConfiguration>(configuration.GetSection("CacheConfiguration"));

            services.RemoveAll(typeof(IMessageRepository));
            services.AddScoped<IMessageRepository, CacheMessageRepository>();
            services.AddScoped<MessageRepository>();

            services.AddMemoryCache();

            services.AddScoped<ICacheService, MemoryCacheService>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMessageRepository, MessageRepository>();
        }
    }
}
