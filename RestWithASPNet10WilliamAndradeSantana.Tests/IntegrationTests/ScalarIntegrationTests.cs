using RestWithASPNet10WilliamAndradeSantana.Tests.IntegrationTests.Tools;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace RestWithASPNet10WilliamAndradeSantana.Tests.IntegrationTests;

public class ScalarIntegrationTests : IClassFixture<SqlServerFixture>
{
    private readonly HttpClient _httpClient;

    public ScalarIntegrationTests(SqlServerFixture sqlFixture)
    {
        var factory = new CustomWebApplicationFactory<Program>(sqlFixture.ConnectionString);
        _httpClient = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri("http://localhost")
        });
    }

    [Fact]
    public async Task Scalar_ShouldReturnScalarUI()
    {
        // arrange & act
        var response = await _httpClient.GetAsync("/scalar/");

        // assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNull();
        content.Should().Contain("ASP.NET 2026 REST API's from 0 to Azure and GCP with .NET 10, Docker and Kubernetes");
    }
}
