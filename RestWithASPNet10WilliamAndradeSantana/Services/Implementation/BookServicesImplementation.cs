using Mapster;
using RestWithASPNet10WilliamAndradeSantana.Data.DTO.V1;
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
    public List<BookDTO> GetBooks()
    {
        return _repository.GetAll().Adapt<List<BookDTO>>();
    }

    public BookDTO GetBookById(long id)
    {
        return _repository.FindById(id).Adapt<BookDTO>();
    }

    public BookDTO CreateBook(BookDTO book)
    {
        var entity = book.Adapt<Book>();
        entity = _repository.Create(entity);
        return entity.Adapt<BookDTO>();
    }


    public BookDTO UpdateBook(BookDTO book)
    {
        var entity = book.Adapt<Book>();
        entity = _repository.Update(entity);
        return entity.Adapt<BookDTO>();
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