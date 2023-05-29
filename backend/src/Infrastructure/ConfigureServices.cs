using GameApp.Infrastructure.Services;
using GameApp.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawgSharp;

namespace GameApp.Infrastructure
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
