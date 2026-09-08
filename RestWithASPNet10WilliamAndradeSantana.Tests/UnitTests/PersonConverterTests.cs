using FluentAssertions;
using RestWithASPNet10WilliamAndradeSantana.Data.Converter.Implementation;
using RestWithASPNet10WilliamAndradeSantana.Data.DTO.V2;
using RestWithASPNet10WilliamAndradeSantana.Model;

namespace RestWithASPNet10WilliamAndradeSantana.Tests.UnitTests;

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

    [Fact]
    public void ParseList_ShouldConvertPersonDTOListToPersonList()
    {
        // Arrange
        var dtos = new List<PersonDTO>
        {
            new PersonDTO{ Id = 1, FirstName = "Mahatma", LastName = "Gandhi", Address = "Porbandar - India", Gender = "Male", BirthDay = new DateTime(1869, 10, 2) },
            new PersonDTO{ Id = 2, FirstName = "Martin", LastName = "Luther King Jr.", Address = "Atlanta", Gender = "Male", BirthDay = new DateTime(1929, 8, 28) }
        };

        var expectedPersons = new List<Person>
        {
            new Person{ Id = 1, FirstName = "Mahatma", LastName = "Gandhi", Address = "Porbandar - India", Gender = "Male" },
            new Person{ Id = 2, FirstName = "Martin", LastName = "Luther King Jr.", Address = "Atlanta", Gender = "Male" }
        };

        // Act
        var persons = _converter.ParseList(dtos);

        // Assert
        persons.Should().NotBeNull();
        persons.Count.Should().Be(expectedPersons.Count);
        persons.Should().HaveCount(2);
        persons.Should().BeEquivalentTo(expectedPersons);
        
        persons[0].Should().BeEquivalentTo(expectedPersons[0]);
        persons[1].Should().BeEquivalentTo(expectedPersons[1]);
        persons[0].FirstName.Should().Be(expectedPersons[0].FirstName);
        persons[1].FirstName.Should().Be(expectedPersons[1].FirstName);
    }

    [Fact]
    public void ParseList_NullPersonDTOListShouldReturnNull()
    {
        // Arrange
        List<PersonDTO> dtos = null;

        // Act
        var persons = _converter.ParseList(dtos);

        // Assert
        persons.Should().BeNull();
    }

    [Fact]
    public void ParseList_ShouldConvertPersonListToPersonDTOList()
    {
        // Arrange
        var persons = new List<Person>
        {
            new Person { Id = 1, FirstName = "Mahatma", LastName = "Gandhi", Address = "Porbandar - India", Gender = "Male", },
            new Person { Id = 2, FirstName = "Martin", LastName = "Luther King Jr.", Address = "Atlanta", Gender = "Male", }
        };

        var expectedDTOs = new List<PersonDTO>
        {
            new PersonDTO{ Id = 1, FirstName = "Mahatma", LastName = "Gandhi", Address = "Porbandar - India", Gender = "Male", BirthDay = DateTime.Now },
            new PersonDTO{ Id = 2, FirstName = "Martin", LastName = "Luther King Jr.", Address = "Atlanta", Gender = "Male", BirthDay = DateTime.Now }
        };

        // Act
        var dtos = _converter.ParseList(persons);

        // Assert
        dtos.Should().NotBeNull();
        dtos.Count.Should().Be(expectedDTOs.Count);
        dtos.Should().HaveCount(2);
        dtos.Should().BeEquivalentTo(expectedDTOs, options => options.Excluding(dto => dto.BirthDay));

        dtos[0].Should().BeEquivalentTo(expectedDTOs[0], options => options.Excluding(dto => dto.BirthDay));
        dtos[1].Should().BeEquivalentTo(expectedDTOs[1], options => options.Excluding(dto => dto.BirthDay));
        dtos[0].FirstName.Should().Be(expectedDTOs[0].FirstName);
        dtos[1].FirstName.Should().Be(expectedDTOs[1].FirstName);
    }

    [Fact]
    public void ParseList_NullPersonListShouldReturnNull()
    {
        // Arrange
        List<Person> persons = null;

        // Act
        var dtos = _converter.ParseList(persons);

        // Assert
        dtos.Should().BeNull();
    }
}