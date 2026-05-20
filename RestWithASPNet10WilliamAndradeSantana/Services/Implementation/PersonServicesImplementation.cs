using RestWithASPNet10WilliamAndradeSantana.Model;
using RestWithASPNet10WilliamAndradeSantana.Repositories;

namespace RestWithASPNet10WilliamAndradeSantana.Services.Implementation;

public class PersonServicesImplementation : IPersonServices
{
    private IRepository<Person> _repository;

    public PersonServicesImplementation(IRepository<Person> repository)
    {
        _repository = repository;
    }

    public List<Person> FindAll()
    {
        return _repository.GetAll();
    }

    public Person FindById(long id)
    {
        return _repository.FindById(id);
    }

    public Person Create(Person person)
    {
        return _repository.Create(person);
    }

    public Person Update(Person person)
    {
        return _repository.Update(person);
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }

    public bool ExistsPerson(long id)
    {
        return _repository.Exists(id);
    }
}