using Microsoft.EntityFrameworkCore;
using RestWithASPNet10WilliamAndradeSantana.Model.Context;

namespace RestWithASPNet10WilliamAndradeSantana.Configurations;

public static class DatabaseConfig
{
    public static IServiceCollection AddDatabaseConfiguration (
        this IServiceCollection services, IConfiguration configuration
    ) 
    {
        var connectionString = configuration["MSSQLServerSQLConnection:MSSQLServerSQLConnectionString"];
        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentNullException("Connection string 'MSSQLServerSQLConnectionString' is not configured.");

        services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(connectionString));
        return services;
    }
}
