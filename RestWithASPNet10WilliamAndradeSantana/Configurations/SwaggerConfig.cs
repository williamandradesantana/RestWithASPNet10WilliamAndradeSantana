using Microsoft.OpenApi.Models;

namespace RestWithASPNet10WilliamAndradeSantana.Configurations;

public static class SwaggerConfig
{
    private static readonly string AppName = "ASP.NET 2026 REST API's from 0 to Azure and GCP with .NET 10, Docker and Kubernetes";
    private static readonly string AppDescription = $"REST API's RESTful developed in course {AppName}";

    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
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
            options.CustomSchemaIds(type => type.FullName);
        });
        return services;
    }

    public static IApplicationBuilder UseSwaggerSpecification(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = "swagger-ui";
            options.DocumentTitle = AppName;
        });
        return app;
    }
}