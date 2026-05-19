using RestWithASPNet10WilliamAndradeSantana.Model.Base;

namespace RestWithASPNet10WilliamAndradeSantana.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    List<T> GetAll();
    T FindById(long id);
    T Create(T item);
    T Update(T item);
    void Delete(long id);
    bool Exists(long id);
}