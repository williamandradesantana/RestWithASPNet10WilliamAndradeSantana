using RestWithASPNet10WilliamAndradeSantana.Model;

namespace RestWithASPNet10WilliamAndradeSantana.Repositories;
public interface IBookRepository
{
    List<Book> FindAll();
    Book FindById(long id);
    Book CreateBook(Book book);
    Book UpdateBook(Book book);
    void DeleteBook(long id);
}
