using RestWithASPNet10WilliamAndradeSantana.Data.DTO.V2;

namespace RestWithASPNet10WilliamAndradeSantana.Services;

public interface IPersonServicesV2
{
    PersonDTO Create(PersonDTO person);
    PersonDTO FindById(long id);
    List<PersonDTO> FindAll();
    PersonDTO Update(PersonDTO person);
    void Delete(long id);
    bool ExistsPerson(long id);
}