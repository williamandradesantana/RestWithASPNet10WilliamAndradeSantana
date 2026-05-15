using RestWithASPNet10WilliamAndradeSantana.Model;

namespace RestWithASPNet10WilliamAndradeSantana.Repositories;
public interface IPersonRepository
{
    List<Person> FindAll();
    Person FindById(long id);
    Person Create(Person person);
    Person Update(Person person);
    void Delete(long id);
}