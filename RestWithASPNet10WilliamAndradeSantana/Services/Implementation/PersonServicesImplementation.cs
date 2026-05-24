using RestWithASPNet10WilliamAndradeSantana.Data.Converter.Implementation;
using RestWithASPNet10WilliamAndradeSantana.Data.DTO.V1;
using RestWithASPNet10WilliamAndradeSantana.Model;
using RestWithASPNet10WilliamAndradeSantana.Repositories;

namespace RestWithASPNet10WilliamAndradeSantana.Services.Implementation;

public class PersonServicesImplementation : IPersonServices
{
    private IRepository<Person> _repository;
    private readonly PersonConverter _converter;

    public PersonServicesImplementation(IRepository<Person> repository)
    {
        _repository = repository;
        _converter = new PersonConverter();
    }

    public List<PersonDTO> FindAll()
    {
        return _converter.ParseList(_repository.GetAll()).ToList();
    }

    public PersonDTO FindById(long id)
    {
        return _converter.Parse(_repository.FindById(id));
    }

    public PersonDTO Create(PersonDTO person)
    {
        var entity = _converter.Parse(person);
        entity = _repository.Create(entity);
        return _converter.Parse(entity);
    }

    public PersonDTO Update(PersonDTO person)
    {
        var entity = _converter.Parse(person);
        entity = _repository.Update(entity);
        return _converter.Parse(entity);
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