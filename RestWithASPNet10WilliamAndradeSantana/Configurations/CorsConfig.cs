namespace RestWithASPNet10WilliamAndradeSantana.Configurations;

public static class CorsConfig
{
    public static IServiceCollection AddCorsConfiguration(
        this IServiceCollection services, IConfiguration configuration)
    {
        string[] origins = configuration.GetSection("Cors:Origins")
            .Get<string[]>() ?? Array.Empty<string>();
        
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

    public static IApplicationBuilder UseCorsConfiguration(this IApplicationBuilder app)
    {
        //app.UseCors();
        app.UseCors("DefaultPolicy");
        return app;
    }
}
