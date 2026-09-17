using RestWithASPNet10WilliamAndradeSantana.Model;
using RestWithASPNet10WilliamAndradeSantana.Model.Context;

namespace RestWithASPNet10WilliamAndradeSantana.Repositories.Implementation;

public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    public PersonRepository(MSSQLContext context): base(context) { }
    
    public Person Disable(long id)
    {
        var entity = FindById(id);
        if (entity == null) return null;
        entity.Enabled = false;
        _context.SaveChanges();
        return entity;
    }
}
