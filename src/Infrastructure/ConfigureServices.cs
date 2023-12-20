

using Infrastructure.Persistants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(configuration.GetConnectionString("UserDataHubConnectionString")));
            return services;
        }
    }
}
