using RestWithASPNet10WilliamAndradeSantana.Data.Converter.Contract;
using RestWithASPNet10WilliamAndradeSantana.Data.DTO.V1;
using RestWithASPNet10WilliamAndradeSantana.Model;

namespace RestWithASPNet10WilliamAndradeSantana.Data.Converter.Implementation;

public class BookConverter : IParser<Book, BookDTO>, IParser<BookDTO, Book>
{
    public Book Parse(BookDTO origin)
    {
        if (origin == null) return null;
        return new Book
        {
            Id = origin.Id,
            Title = origin.Title,
            Author = origin.Author,
            Price = origin.Price,
            LaunchDate = origin.LaunchDate,
        };
    }

    public BookDTO Parse(Book origin)
    {
        if (origin == null) return null;
        return new BookDTO
        {
            Id = origin.Id,
            Title = origin.Title,
            Author = origin.Author,
            Price = origin.Price,
            LaunchDate = origin.LaunchDate
        };
    }

    public List<Book> ParseList(List<BookDTO> origin)
    {
        if (origin == null) return null;
        return origin.Select(item => Parse(item)).ToList();
    }

    public List<BookDTO> ParseList(List<Book> origin)
    {
        if (origin == null) return null;
        return origin.Select(item => Parse(item)).ToList();
    }
}