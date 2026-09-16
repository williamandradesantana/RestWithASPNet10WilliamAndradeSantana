using RestWithASPNet10WilliamAndradeSantana.Model;

namespace RestWithASPNet10WilliamAndradeSantana.Repositories;

public interface IPersonRepository : IRepository<Person>
{
    Person Disable(long id);
}
