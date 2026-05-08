using RestWithASPNet10WilliamAndradeSantana.Model;

namespace RestWithASPNet10WilliamAndradeSantana.Services;

public interface IPersonServices
{
    Person CreatePerson(Person person);
    Person FindById(long id);
    List<Person> FindAll();
    Person UpdatePerson(Person person);
    void DeletePerson(long id);
}