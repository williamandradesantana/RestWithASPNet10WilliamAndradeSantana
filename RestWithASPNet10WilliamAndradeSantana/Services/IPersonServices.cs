using RestWithASPNet10WilliamAndradeSantana.Data.DTO;

namespace RestWithASPNet10WilliamAndradeSantana.Services;

public interface IPersonServices
{
    PersonDTO Create(PersonDTO person);
    PersonDTO FindById(long id);
    List<PersonDTO> FindAll();
    PersonDTO Update(PersonDTO person);
    void Delete(long id);
    bool ExistsPerson(long id);
}