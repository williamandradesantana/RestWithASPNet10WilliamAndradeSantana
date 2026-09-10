namespace RestWithASPNet10WilliamAndradeSantana.Configurations;

public static class CorsConfig
{
    public static IServiceCollection AddCorsConfiguration(
        this IServiceCollection services, IConfiguration configuration)
    {
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
                policy.WithOrigins(
                    "http://localhost:3000", 
                    "http://localhost:8080",
                    "https://williamsantana-portfolio.vercel.app/"
                    )
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });
        return services;
    }

    public static IApplicationBuilder UseCorsConfiguration(this IApplicationBuilder app)
    {
        app.UseCors();
        return app;
    }
}
