using FluentAssertions;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using RestWithASPNet10WilliamAndradeSantana.Data.DTO.V1;
using RestWithASPNet10WilliamAndradeSantana.Tests.IntegrationTests.Tools;
using System.Net.Http.Headers;
using static RestWithASPNet10WilliamAndradeSantana.Tests.IntegrationTests.Tools.PriorityOrderer;

namespace RestWithASPNet10WilliamAndradeSantana.Tests.IntegrationTests.Person.XML;

[TestCaseOrderer(
    "RestWithASPNet10WilliamAndradeSantana.Tests.IntegrationTests.Tools.PriorityOrderer",
    "RestWithASPNet10WilliamAndradeSantana.Tests"
    )
]
public class PersonControllerXMLTests : IClassFixture<SqlServerFixture>
{
    private readonly HttpClient _httpClient;
    private static PersonDTO _person;

    public PersonControllerXMLTests(SqlServerFixture sqlFixture)
    {
        var factory = new CustomWebApplicationFactory<Program>(sqlFixture.ConnectionString);
        _httpClient = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri("http://localhost")
        });

        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/xml"));
    }

    [Fact(DisplayName = "01 - Create Person with xml")]
    [TestPriority(1)]
    public async Task CreatePerson_ShouldReturnCreatedPerson()
    {
        // arrange
        PersonDTO request = new PersonDTO
        {
            FirstName = "William",
            LastName = "Santana",
            Address = "Aracaju - Sergipe - Brazil",
            Gender = "Male",
            Enabled = true
        };

        // act
        var response = await _httpClient
            .PostAsync("/api/people/v1", XMLHelper.SerializeToXML(request));

        // assert
        response.EnsureSuccessStatusCode();

        var created = await XMLHelper.ReadFromXmlAsync<PersonDTO>(response);
        created.Should().NotBeNull();
        created.Id.Should().BeGreaterThan(0);
        created.FirstName.Should().Be(request.FirstName);
        created.LastName.Should().Be(request.LastName);
        created.Address.Should().Be(request.Address);
        created.Gender.Should().Be(request.Gender);
        created.Enabled.Should().BeTrue();

        _person = created;
    }

    [Fact(DisplayName = "02 - Update Person with xml")]
    [TestPriority(2)]
    public async Task UpdatePerson_ShouldReturnUpdatedPerson()
    {
        _person.LastName = "Andrade";

        var response = await _httpClient
            .PutAsync("/api/people/v1/", XMLHelper.SerializeToXML(_person));

        response.EnsureSuccessStatusCode();

        var updatedPerson = await XMLHelper.ReadFromXmlAsync<PersonDTO>(response);
        updatedPerson.Should().NotBeNull();
        updatedPerson.Id.Should().BeGreaterThan(0);
        updatedPerson.FirstName.Should().Be(_person.FirstName);
        updatedPerson.LastName.Should().Be(_person.LastName);
        updatedPerson.Address.Should().Be(_person.Address);
        updatedPerson.Gender.Should().Be(_person.Gender);
        updatedPerson.Enabled.Should().BeTrue();

        _person = updatedPerson;
    }

    [Fact(DisplayName = "03 - Disable Person by id")]
    [TestPriority(3)]
    public async Task DisablePersonById_ShouldReturnDisabledPerson() 
    {
        var response = await _httpClient.PatchAsync($"/api/people/v1/{_person.Id}", null);
        response.EnsureSuccessStatusCode();
        
        var disabledPerson = await XMLHelper.ReadFromXmlAsync<PersonDTO>(response);
        disabledPerson.Should().NotBeNull();
        disabledPerson.Id.Should().BeGreaterThan(0);
        disabledPerson.FirstName.Should().Be(_person.FirstName);
        disabledPerson.LastName.Should().Be(_person.LastName);
        disabledPerson.Address.Should().Be(_person.Address);
        disabledPerson.Gender.Should().Be(_person.Gender);
        disabledPerson.Enabled.Should().BeFalse();

        _person = disabledPerson;
    }

    [Fact(DisplayName = "04 - Get Person by id")]
    [TestPriority(4)]
    public async Task GetPersonById_ShouldReturnPerson() 
    {
        var response = await _httpClient.GetAsync($"/api/people/v1/{_person.Id}");
        response.EnsureSuccessStatusCode();
        
        var person = await XMLHelper.ReadFromXmlAsync<PersonDTO>(response);
        person.Should().NotBeNull();
        person.Id.Should().BeGreaterThan(0);
        person.FirstName.Should().Be(_person.FirstName);
        person.LastName.Should().Be(_person.LastName);
        person.Address.Should().Be(_person.Address);
        person.Gender.Should().Be(_person.Gender);
        person.Enabled.Should().BeFalse();

        _person = person;
    }

    [Fact(DisplayName = "05 - Delete Person by id")]
    [TestPriority(5)]
    public async Task DeletePersonById_ShouldReturnNoContent() 
    {
        var response = await _httpClient.DeleteAsync($"/api/people/v1/{_person.Id}");
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact(DisplayName = "06 - Find all people")]
    [TestPriority(6)]
    public async Task FindAllPerson_ShouldReturnListOfPerson() 
    {
        var response = await _httpClient.GetAsync("/api/people/v1");
        response.EnsureSuccessStatusCode();

        List<PersonDTO> people = await XMLHelper.ReadFromXmlAsync<List<PersonDTO>>(response);
        people.Should().NotBeNull();
        people.Count.Should().BeGreaterThan(0);

        PersonDTO first = people.First(person => person.FirstName == "John");
        first.LastName.Should().Be("Doe");
        first.Address.Should().Be("123 Main St");
        first.Enabled.Should().BeTrue();
        first.Gender.Should().Be("Male");

        PersonDTO second = people.First(person => person.FirstName == "Leonardo");
        second.LastName.Should().Be("Da Vinci");
        second.Address.Should().Be("Anchiano - Italy");
        second.Enabled.Should().BeTrue();
        second.Gender.Should().Be("Male");
    }
}
