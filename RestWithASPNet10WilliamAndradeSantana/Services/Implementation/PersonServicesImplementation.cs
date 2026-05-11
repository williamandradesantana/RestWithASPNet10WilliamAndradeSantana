using RestWithASPNet10WilliamAndradeSantana.Model;
using RestWithASPNet10WilliamAndradeSantana.Model.Context;

namespace RestWithASPNet10WilliamAndradeSantana.Services.Implementation;

public class PersonServicesImplementation : IPersonServices
{
    private MSSQLContext _context;

    public PersonServicesImplementation(MSSQLContext context)
    {
        _context = context;
    }

    public List<Person> FindAll()
    {
        return _context.Persons.OrderByDescending((person) => person.FirstName).ToList(); ;
    }

    public Person FindById(long id)
    {
        var person = _context.Persons.FirstOrDefault((p) => p.Id == id);
        if (person == null)
        {
            throw new KeyNotFoundException("Person not found!");
        }
        return person;
    }

    public Person CreatePerson(Person person)
    {
        person.Id = Random.Shared.Next(1, 10000);
        return person;
    }

    public Person UpdatePerson(Person person)
    {
        return person;
    }

    public void DeletePerson(long id)
    {
        // Simulate deletion logic
    }

    private Person MockPerson(int i)
    {
        return new Person
        {
            Id = Random.Shared.Next(1, 10000),
            FirstName = "William " + i,
            LastName = "Andrade " + i,
            Address = "Aracaju - SE - Brazil " + i,
            Gender = (i % 2 == 0) ? "Male" : "Female"
        };
    }
}