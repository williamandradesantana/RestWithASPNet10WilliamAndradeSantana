namespace RestWithASPNet10WilliamAndradeSantana.Configurations;

public static class CorsConfig
{

    private static string[] GetAllowedOrigins(IConfiguration configuration)
    {
        return configuration.GetSection("Cors:Origins")
            .Get<string[]>() ?? Array.Empty<string>();
    }

    public static IServiceCollection AddCorsConfiguration(
        this IServiceCollection services, IConfiguration configuration)
    {
        string[] origins = GetAllowedOrigins(configuration);
        
        services.AddCors(options =>
        {
            options.AddPolicy("LocalPolicy", policy =>
            {
                policy.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });

            options.AddPolicy("MultipleOriginPolicy", policy =>
            {
                policy.WithOrigins(origins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });

            options.AddPolicy("DefaultPolicy", policy =>
            {
                policy.WithOrigins(origins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });
        return services;
    }

    public static IApplicationBuilder UseCorsConfiguration(
        this IApplicationBuilder app, IConfiguration configuration
        )
    {
        var origins = GetAllowedOrigins(configuration);

        app.Use(async (context, next) =>
        {
            var origin = context.Request.Headers["Origin"].ToString();
            if (
                !string.IsNullOrEmpty(origin) && !origins.Contains(origin, StringComparer.OrdinalIgnoreCase)
               )
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("CORS origin not allowed.");
                return;
            }
            await next();
        });

        app.UseCors("DefaultPolicy");
        return app;
        //app.UseCors();
    }
}
