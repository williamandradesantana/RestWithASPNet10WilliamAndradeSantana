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

    // Person to PersonDTO conversion tests
    [Fact]
    public void Parse_ShouldConvertPersonToPersonDTO()
    {
        // Arrange: prepare the data, objects, and dependencies required for the test
        var entity = new Person
        {
            Id = 1,
            FirstName = "Mahatma",
            LastName = "Gandhi",
            Address = "Porbandar - India",
            Gender = "Male"
        };

        var expectedPersonDTO = new PersonDTO
        {
            Id = 1,
            FirstName = "Mahatma",
            LastName = "Gandhi",
            Address = "Porbandar - India",
            Gender = "Male",
            BirthDay = DateTime.Now
        };

        // Act: execute the method or functionallity under test
        var dto = _converter.Parse(entity);

        // Assert: verify that the person matches the expected outcome 
        dto.Should().NotBeNull();
        dto.Id.Should().Be(expectedPersonDTO.Id);
        dto.FirstName.Should().Be(expectedPersonDTO.FirstName);
        dto.LastName.Should().Be(expectedPersonDTO.LastName);
        dto.Address.Should().Be(expectedPersonDTO.Address);
        dto.Gender.Should().Be(expectedPersonDTO.Gender);
        dto.Should().BeEquivalentTo(expectedPersonDTO, options => options.Excluding(person => person.BirthDay));
        dto.BirthDay.Should().NotBeNull();
    }

    [Fact]
    public void Parse_NullPersonShouldReturnNull()
    {
        // Arrange
        Person entity = null;

        // Act
        var dto = _converter.Parse(entity);

        // Assert
        dto.Should().BeNull();
    }
}