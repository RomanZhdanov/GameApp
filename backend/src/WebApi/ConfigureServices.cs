using FluentValidation.AspNetCore;
using GameApp.Application.Common.Interfaces;
using GameApp.Infrastructure.Data;
using GameApp.WebApi.Filters;
using GameApp.WebApi.Services;

namespace GameApp.WebApi;

public static class ConfigureServices
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();
        
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddControllersWithViews(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

        services.AddCors(opt =>
        {
            opt.AddPolicy("frontend-origins", corsBuilder => corsBuilder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins(configuration.GetSection("CorsOrigins").Get<string[]>())
                .AllowCredentials());
        });

        services.AddRazorPages();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
