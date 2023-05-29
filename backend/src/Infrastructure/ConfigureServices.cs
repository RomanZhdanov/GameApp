using GameList.Application.Common.Interfaces;
using GameList.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawgSharp;

namespace GameList.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRawgClient();
            services.AddTransient<IGamesDbService, GamesDbService>();

            return services;
        }
    }
}
