using RestWithASPNet10WilliamAndradeSantana.Tests.IntegrationTests.Tools;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace RestWithASPNet10WilliamAndradeSantana.Tests.IntegrationTests;

public  class SwaggerIntegrationTests : IClassFixture<SqlServerFixture>
{
    private readonly HttpClient _httpClient;

    public SwaggerIntegrationTests(SqlServerFixture sqlFixture)
    {
        var factory = new CustomWebApplicationFactory<Program>(sqlFixture.ConnectionString);
        _httpClient = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri("http://localhost")
        });
    }

    [Fact]
    public async Task SwaggerJson_ShouldReturnSwaggerJson()
    {
        // arrange & act
        var response = await _httpClient.GetAsync("/swagger/v1/swagger.json");

        // assert
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNull();
        content.Should().Contain("/api/books/v1");
        content.Should().Contain("\"openapi\": \"3.0.4\"", content);
        content.Should().Contain(
            "\"title\": \"ASP.NET 2026 REST API's from 0 to Azure and GCP with .NET 10, Docker and Kubernetes\"", 
            content
        );
    }
}
