using RestWithASPNet10WilliamAndradeSantana.Model;
using RestWithASPNet10WilliamAndradeSantana.Model.Context;

namespace RestWithASPNet10WilliamAndradeSantana.Services.Implementation;

public class PersonServicesImplementation : IPersonServices
{
    private readonly MSSQLContext _context;

    public PersonServicesImplementation(MSSQLContext context)
    {
        _context = context;
    }

    public List<Person> FindAll()
    {
        return _context.Persons.OrderByDescending((person) => person.FirstName).ToList();
    }

    public Person FindById(long id)
    {
        var person = _context.Persons.FirstOrDefault((p) => p.Id == id);
        return (person == null) ? throw new KeyNotFoundException($"Person with id {id} not found") : person;
    }

    public Person CreatePerson(Person person)
    {
        _context.Persons.Add(person);
        _context.SaveChanges();
        return person;
    }

    public Person UpdatePerson(Person person)
    {
        var personFound = FindById(person.Id);   
        _context.Entry(personFound).CurrentValues.SetValues(person);
        _context.SaveChanges();
        return personFound;
    }

    public void DeletePerson(long id)
    {
        var person = FindById(id);
        _context.Persons.Remove(person);
        _context.SaveChanges();
    }
}