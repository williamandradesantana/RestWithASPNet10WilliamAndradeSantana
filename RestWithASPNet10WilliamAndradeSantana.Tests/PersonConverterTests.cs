using FluentAssertions;
using RestWithASPNet10WilliamAndradeSantana.Data.Converter.Implementation;
using RestWithASPNet10WilliamAndradeSantana.Data.DTO.V2;
using RestWithASPNet10WilliamAndradeSantana.Model;

namespace RestWithASPNet10WilliamAndradeSantana.Tests;

public class PersonConverterTests
{
    private readonly PersonConverterV2 _converter;
    public PersonConverterTests()
    {
        _converter = new PersonConverterV2();
    }

    // PersonDTO to Person conversion tests
    [Fact]
    public void Parse_ShouldConvertPersonDTOToPerson()
    {
        // Arrange: prepare the data, objects, and dependencies required for the test
        var dto = new PersonDTO
        {
            Id = 1,
            FirstName = "Mahatma",
            LastName = "Gandhi",
            Address = "Porbandar - India",
            Gender = "Male",
            BirthDay = new DateTime(1869, 10, 2)
        };

        var expectedPerson = new Person
        {
            Id = 1,
            FirstName = "Mahatma",
            LastName = "Gandhi",
            Address = "Porbandar - India",
            Gender = "Male",
        };

        // Act: execute the method or functionallity under test
        var person = _converter.Parse(dto);

        // Assert: verify that the person matches the expected outcome 
        person.Should().NotBeNull();
        person.Id.Should().Be(expectedPerson.Id);
        person.FirstName.Should().Be(expectedPerson.FirstName);
        person.LastName.Should().Be(expectedPerson.LastName);
        person.Address.Should().Be(expectedPerson.Address);
        person.Gender.Should().Be(expectedPerson.Gender);
        person.Should().BeEquivalentTo(expectedPerson);
    }

    [Fact]
    public void Parse_NullPersonDTOShouldReturnNull()
    {
        // Arrange
        PersonDTO dto = null;

        // Act
        var person = _converter.Parse(dto);

        // Assert
        person.Should().BeNull();
    }
}