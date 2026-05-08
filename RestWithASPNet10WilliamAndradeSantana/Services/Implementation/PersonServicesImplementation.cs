using RestWithASPNet10WilliamAndradeSantana.Model;

namespace RestWithASPNet10WilliamAndradeSantana.Services.Implementation;

public class PersonServicesImplementation : IPersonServices
{
    public List<Person> FindAll()
    {
        List<Person> persons = new List<Person>();
        for (int i = 0; i < 8; i++) persons.Add(MockPerson(i));
        return persons;
    }

    public Person FindById(long id)
    {
        var person = MockPerson((int) id);
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