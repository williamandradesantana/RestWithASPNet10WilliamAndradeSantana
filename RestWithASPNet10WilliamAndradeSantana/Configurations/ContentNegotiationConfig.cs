using Microsoft.Net.Http.Headers;

namespace RestWithASPNet10WilliamAndradeSantana.Configurations;

public static class ContentNegotiationConfig
{
    public static IMvcBuilder AddContentNegotiation(this IMvcBuilder builder) 
    {
        return builder.AddMvcOptions(options =>
        {
            options.RespectBrowserAcceptHeader = true;
            options.ReturnHttpNotAcceptable = true;

            options.FormatterMappings.SetMediaTypeMappingForFormat(
                "json", MediaTypeHeaderValue.Parse("application/json")
            );
            options.FormatterMappings.SetMediaTypeMappingForFormat(
                "xml", MediaTypeHeaderValue.Parse("application/xml")
            );
        }).AddXmlSerializerFormatters();
    }
}