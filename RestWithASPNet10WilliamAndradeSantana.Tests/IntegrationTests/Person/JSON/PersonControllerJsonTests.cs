using RestWithASPNet10WilliamAndradeSantana.Tests.IntegrationTests.Tools;
using Microsoft.AspNetCore.Mvc.Testing;
using static RestWithASPNet10WilliamAndradeSantana.Tests.IntegrationTests.Tools.PriorityOrderer;
using RestWithASPNet10WilliamAndradeSantana.Data.DTO.V1;
using System.Net.Http.Json;
using FluentAssertions;

namespace RestWithASPNet10WilliamAndradeSantana.Tests.IntegrationTests.Person;

[TestCaseOrderer(
    "RestWithASPNet10WilliamAndradeSantana.Tests.IntegrationTests.Tools.PriorityOrderer",
    "RestWithASPNet10WilliamAndradeSantana.Tests"
    )
]
public class PersonControllerJsonTests : IClassFixture<SqlServerFixture>
{
    private readonly HttpClient _httpClient;
    private static PersonDTO _person;

    public PersonControllerJsonTests(SqlServerFixture sqlFixture)
    {
        var factory = new CustomWebApplicationFactory<Program>(sqlFixture.ConnectionString);
        _httpClient = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost")
            }
        );
    }

    [Fact(DisplayName = "01 - Create Person")]
    [TestPriority(1)]
    public async Task CreatePerson_ShouldReturnCreatedPerson()
    {
        // arrange
        var request = new PersonDTO
        {
            FirstName = "Linus",
            LastName = "Torvalds",
            Address = "Helsinki - Finland",
            Gender = "Male",
            Enabled = true
        };

        // act
        var response = await _httpClient.PostAsJsonAsync("/api/people/v1", request);

        // assert
        response.EnsureSuccessStatusCode();

        var created = await response.Content.ReadFromJsonAsync<PersonDTO>();
        created.Should().NotBeNull();
        created.Id.Should().BeGreaterThan(0);
        created.FirstName.Should().Be(request.FirstName);
        created.LastName.Should().Be(request.LastName);
        created.Address.Should().Be(request.Address);
        created.Gender.Should().Be(request.Gender);
        created.Enabled.Should().BeTrue();

        _person = created;
    }

    [Fact(DisplayName = "02 - Update Person")]
    [TestPriority(2)]
    public async Task UpdatePerson_ShouldReturnUpdatedPerson()
    {
        // arrange
        _person.LastName = "Benedict Torvalds";

        // act
        var response = await _httpClient.PutAsJsonAsync($"/api/people/v1", _person);

        // assert
        response.EnsureSuccessStatusCode();

        var updated = await response.Content.ReadFromJsonAsync<PersonDTO>();
        updated.Should().NotBeNull();
        updated.Id.Should().BeGreaterThan(0);
        updated.FirstName.Should().Be(_person.FirstName);
        updated.LastName.Should().Be(_person.LastName);
        updated.Address.Should().Be(_person.Address);
        updated.Gender.Should().Be(_person.Gender);
        updated.Enabled.Should().BeTrue();

        _person = updated;
    }

    [Fact(DisplayName = "03 - Get one person")]
    [TestPriority(3)]
    public async Task FindPersonById_ShouldReturnOk()
    {
        var response = await _httpClient.GetAsync($"/api/people/v1/{_person.Id}");

        response.EnsureSuccessStatusCode();

        var found = await response.Content.ReadFromJsonAsync<PersonDTO>();
        found.Should().NotBeNull();
        found.Should().BeEquivalentTo(_person);
        found.FirstName.Should().Be(_person.FirstName);
        found.LastName.Should().Be(_person.LastName);
        found.Address.Should().Be(_person.Address);
    }
}
