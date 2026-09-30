using RestWithASPNet10WilliamAndradeSantana.Hypermedia.Enricher;
using RestWithASPNet10WilliamAndradeSantana.Hypermedia.Filters;

namespace RestWithASPNet10WilliamAndradeSantana.Configurations;

public static class HATEOASConfig
{
    public static IServiceCollection AddHATEOASConfiguration(this IServiceCollection services)
    {
        var filterOptions = new HyperMediaFilterOptions();
        filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
        filterOptions.ContentResponseEnricherList.Add(new BookEnricher());
        
        services.AddSingleton(filterOptions);
        services.AddScoped<HyperMediaFilter>();
        return services;
    }

    public static void UseHATEOASRoutes(this IEndpointRouteBuilder app)
    {
        app.MapControllerRoute("Default", "{controller=values}/v1/{id?}");
    }
}
