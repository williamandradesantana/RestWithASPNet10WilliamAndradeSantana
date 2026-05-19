using Microsoft.EntityFrameworkCore;
using RestWithASPNet10WilliamAndradeSantana.Model.Base;
using RestWithASPNet10WilliamAndradeSantana.Model.Context;

namespace RestWithASPNet10WilliamAndradeSantana.Repositories.Implementation;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly MSSQLContext _context;
    private DbSet<T> _dataset;

    public GenericRepository(MSSQLContext context)
    {
        _context = context;
        _dataset = _context.Set<T>();
    }

    public List<T> GetAll()
    {
        return _dataset.ToList();
    }

    public T FindById(long id)
    {
        return _dataset.Find(id);
    }

    public T Create(T item)
    {
        _dataset.Add(item);
        _context.SaveChanges();
        return item;
    }

    public T Update(T item)
    {
        var existingItem = _dataset.Find(item.Id);
        if (existingItem == null) return null;
        
        _context.Entry(existingItem).CurrentValues.SetValues(item);
        _context.SaveChanges();
        return item;
    }

    public void Delete(long id)
    {
        var existingItem = _dataset.Find(id);
        if (existingItem == null) return;
        _context.Remove(existingItem);
        _context.SaveChanges();
    }

    public bool Exists(long id)
    {
        return _dataset.Any(entity => entity.Id == id);
    }
}