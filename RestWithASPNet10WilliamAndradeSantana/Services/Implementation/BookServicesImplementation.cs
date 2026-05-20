using RestWithASPNet10WilliamAndradeSantana.Model;
using RestWithASPNet10WilliamAndradeSantana.Repositories;

namespace RestWithASPNet10WilliamAndradeSantana.Services.Implementation;

public class BookServicesImplementation : IBookServices
{
    private readonly IRepository<Book> _repository;

    public BookServicesImplementation(IRepository<Book> repository)
    {
        _repository = repository;
    }
    public List<Book> GetBooks()
    {
        return _repository.GetAll();
    }

    public Book GetBookById(long id)
    {
        return _repository.FindById(id);
    }

    public Book CreateBook(Book book)
    {
        return _repository.Create(book);
    }


    public Book UpdateBook(Book book)
    {
        return _repository.Update(book);
    }
    public void DeleteBook(long id)
    {
        _repository.Delete(id);
    }

    public bool ExistsBook(long id)
    {
        return _repository.Exists(id);
    }
}