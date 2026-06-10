using Microsoft.OpenApi.Models;

namespace RestWithASPNet10WilliamAndradeSantana.Configurations;

public static class OpenAPIConfig
{
    private static readonly string AppName = "ASP.NET 2026 REST API's from 0 to Azure and GCP with .NET 10, Docker and Kubernetes";
    private static readonly string AppDescription = $"REST API's RESTful developed in course {AppName}";

    public static IServiceCollection AddOpenAPIConfig(this IServiceCollection services) 
    {
        services.AddSingleton(new OpenApiInfo
        {
            Title = AppName,
            Version = "v1",
            Description = AppDescription,
            Contact = new OpenApiContact
            {
                Name = "William Santana",
                Url = new Uri("https://williamsantana-portfolio.vercel.app/"),
                Email = "williamandrade1058@gmail.com"
            },
            License = new OpenApiLicense
            {
                Name = "MIT License",
                Url = new Uri("https://opensource.org/license/mit/")
            }
        });
        return services;
    }
}
