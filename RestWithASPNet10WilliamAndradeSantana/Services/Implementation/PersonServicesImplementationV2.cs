using RestWithASPNet10WilliamAndradeSantana.Data.Converter.Implementation;
using RestWithASPNet10WilliamAndradeSantana.Data.DTO.V2;
using RestWithASPNet10WilliamAndradeSantana.Model;
using RestWithASPNet10WilliamAndradeSantana.Repositories;

namespace RestWithASPNet10WilliamAndradeSantana.Services.Implementation;

public class PersonServicesImplementationV2 : IPersonServicesV2
{
    private IRepository<Person> _repository;
    private readonly PersonConverterV2 _converter;

    public PersonServicesImplementationV2(IRepository<Person> repository)
    {
        _repository = repository;
        _converter = new PersonConverterV2();
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