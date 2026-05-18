using RestWithASPNet10WilliamAndradeSantana.Model;
using RestWithASPNet10WilliamAndradeSantana.Repositories;

namespace RestWithASPNet10WilliamAndradeSantana.Services.Implementation;

public class BookServicesImplementation : IBookServices
{
    private readonly IBookRepository _repository;

    public BookServicesImplementation(IBookRepository repository)
    {
        _repository = repository;
    }
    public List<Book> GetBooks()
    {
        return _repository.FindAll();
    }

    public Book GetBookById(long id)
    {
        return _repository.FindById(id);
    }

    public Book CreateBook(Book book)
    {
        return _repository.CreateBook(book);
    }


    public Book UpdateBook(Book book)
    {
        return _repository.UpdateBook(book);
    }
    public void DeleteBook(long id)
    {
        _repository.DeleteBook(id);
    }
}