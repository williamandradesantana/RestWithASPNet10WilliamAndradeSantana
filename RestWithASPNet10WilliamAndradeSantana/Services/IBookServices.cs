using RestWithASPNet10WilliamAndradeSantana.Data.DTO.V1;

namespace RestWithASPNet10WilliamAndradeSantana.Services;

public interface IBookServices
{
    List<BookDTO> GetBooks();
    BookDTO GetBookById(long id);
    BookDTO CreateBook(BookDTO book);
    BookDTO UpdateBook(BookDTO book);
    void DeleteBook(long id);
    bool ExistsBook(long id);
}