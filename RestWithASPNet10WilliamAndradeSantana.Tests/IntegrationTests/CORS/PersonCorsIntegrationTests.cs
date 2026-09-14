using RestWithASPNet10WilliamAndradeSantana.Tests.IntegrationTests.Tools;
using Microsoft.AspNetCore.Mvc.Testing;
using static RestWithASPNet10WilliamAndradeSantana.Tests.IntegrationTests.Tools.PriorityOrderer;
using RestWithASPNet10WilliamAndradeSantana.Data.DTO.V1;
using System.Net.Http.Json;
using FluentAssertions;
using System.Net;

namespace RestWithASPNet10WilliamAndradeSantana.Tests.IntegrationTests.CORS;

[TestCaseOrderer(
    "RestWithASPNet10WilliamAndradeSantana.Tests.IntegrationTests.Tools.PriorityOrderer",
    "RestWithASPNet10WilliamAndradeSantana.Tests"
    )
]
public class PersonCorsIntegrationTests : IClassFixture<SqlServerFixture>
{
    private readonly HttpClient _httpClient;
    private static PersonDTO _person;

    public PersonCorsIntegrationTests(SqlServerFixture sqlFixture)
    {
        var factory = new CustomWebApplicationFactory<Program>(sqlFixture.ConnectionString);
        _httpClient = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost")
            }
        );
    }

    private void AddOriginHeader(string origin) 
    {
        _httpClient.DefaultRequestHeaders.Remove("Origin");
        _httpClient.DefaultRequestHeaders.Add("Origin", origin);
    }

    [Fact(DisplayName = "01 - Create Person With Allowed Origin")]
    [TestPriority(1)]
    public async Task CreatePerson_WithAllowdOrigin_ShouldReturnCreated()
    {
        // arrange
        AddOriginHeader("https://williamsantana-portfolio.vercel.app/");

        var request = new PersonDTO
        {
            FirstName = "Richard",
            LastName = "Stallman",
            Address = "New York City - New York - USA",
            Gender = "Male",
        };

        // act
        var response = await _httpClient.PostAsJsonAsync("/api/people/v1", request);

        // assert
        response.EnsureSuccessStatusCode();

        var created = await response.Content.ReadFromJsonAsync<PersonDTO>();
        created.Should().NotBeNull();
        created.Id.Should().BeGreaterThan(0);

        _person = created;
    }

    [Fact(DisplayName = "02 - Create Person With Disallowed Origin")]
    [TestPriority(2)]
    public async Task CreatePerson_WithDisallowdOrigin_ShouldReturnForbidden()
    {
        // arrange
        AddOriginHeader("https://semeru.com.br");

        var request = new PersonDTO
        {
            FirstName = "Richard",
            LastName = "Stallman",
            Address = "New York City - New York - USA",
            Gender = "Male",
        };

        // act
        var response = await _httpClient.PostAsJsonAsync("/api/people/v1", request);

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.Forbidden);

        var content = await response.Content.ReadAsStringAsync();
        content.Should().Be("CORS origin not allowed.");
    }

    [Fact(DisplayName = "03 - Get one person with allowed origin")]
    [TestPriority(3)]
    public async Task FindPersonById_WithAllowedOrigin_ShouldReturnOk()
    {
        AddOriginHeader("http://localhost:3000");

        var response = await _httpClient.GetAsync($"/api/people/v1/{_person.Id}");

        response.EnsureSuccessStatusCode();

        var found = await response.Content.ReadFromJsonAsync<PersonDTO>();
        found.Should().NotBeNull();
        found.Should().BeEquivalentTo(_person);
        found.FirstName.Should().Be(_person.FirstName);
        found.LastName.Should().Be(_person.LastName);
        found.Address.Should().Be(_person.Address);
    }

    [Fact(DisplayName = "04 - Get one person with disallowed origin")]
    [TestPriority(4)]
    public async Task FindPersonById_WithDisallowedOrigin_ShouldReturnForbidden()
    {
        AddOriginHeader("http://localhost:3001");

        var response = await _httpClient.GetAsync($"/api/people/v1/{_person.Id}");

        response.StatusCode.Should().Be(HttpStatusCode.Forbidden);

        var content = await response.Content.ReadAsStringAsync();
        content.Should().Be("CORS origin not allowed.");
    }
}
