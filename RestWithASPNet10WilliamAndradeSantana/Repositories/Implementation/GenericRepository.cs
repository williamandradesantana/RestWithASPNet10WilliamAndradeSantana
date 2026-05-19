using RestWithASPNet10WilliamAndradeSantana.Model.Base;
using RestWithASPNet10WilliamAndradeSantana.Model.Context;

namespace RestWithASPNet10WilliamAndradeSantana.Repositories.Implementation;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly MSSQLContext _context;

    public GenericRepository(MSSQLContext context)
    {
        _context = context;
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T FindById(long id)
    {
        return _context.Set<T>().Find(id);
    }

    public T Create(T item)
    {
        throw new NotImplementedException();
    }

    public T Update(T item)
    {
        throw new NotImplementedException();
    }

    public void Delete(long id)
    {
        throw new NotImplementedException();
    }

    public bool Exists(long id)
    {
        throw new NotImplementedException();
    }
}