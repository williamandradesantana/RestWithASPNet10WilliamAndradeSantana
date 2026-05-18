using RestWithASPNet10WilliamAndradeSantana.Model;

namespace RestWithASPNet10WilliamAndradeSantana.Services;

public interface IBookServices
{
    List<Book> GetBooks();
    Book GetBookById(long id);
    Book CreateBook(Book book);
    Book UpdateBook(Book book);
    void DeleteBook(long id);
}