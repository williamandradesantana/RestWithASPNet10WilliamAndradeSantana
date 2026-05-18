using RestWithASPNet10WilliamAndradeSantana.Model;
using RestWithASPNet10WilliamAndradeSantana.Model.Context;

namespace RestWithASPNet10WilliamAndradeSantana.Repositories.Implementation;

public class BookRepository : IBookRepository
{
    private readonly MSSQLContext _context;

    public BookRepository(MSSQLContext context)
    {
        _context = context;
    }

    public List<Book> FindAll()
    {
        return _context.Books.ToList();
    }

    public Book FindById(long id)
    {
        return _context.Books.Find(id);
    }

    public Book CreateBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
        return book;
    }

    public Book UpdateBook(Book book)
    {
        var existingBook = _context.Books.Find(book.Id);
        if (existingBook == null) return null;
       
        _context.Entry(existingBook).CurrentValues.SetValues(book);
        _context.SaveChanges();
        return book;
    }

    public void DeleteBook(long id)
    {
        var existingBook = _context.Books.Find(id);
        if (existingBook == null) return;
        
        _context.Books.Remove(existingBook);
        _context.SaveChanges();
    }
}