using Microsoft.AspNetCore.Mvc;
using RestWithASPNet10WilliamAndradeSantana.Data.DTO.V1;
using RestWithASPNet10WilliamAndradeSantana.Services;

namespace RestWithASPNet10WilliamAndradeSantana.Controllers.V1;

[ApiController]
[Route("api/books/v1")]
public class BookController : ControllerBase
{
    private IBookServices _services;
    private readonly ILogger<BookController> _logger;
    public BookController(IBookServices services, ILogger<BookController> logger)
    {
        _services = services;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        _logger.LogInformation("Fetching all books");
        return Ok(_services.GetBooks());
    }

    [HttpGet("{id}")]
    public IActionResult GetBookById(long id) 
    {
       _logger.LogInformation("Fetching book with ID {id}", id);
        var book = _services.GetBookById(id);
        if (book == null) 
        { 
            _logger.LogWarning("Book with ID {id} not found", id);
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public IActionResult CreateBook([FromBody] BookDTO book)
    {
        _logger.LogInformation("Creating a new book with title {title}", book.Title);
        var createdBook = _services.CreateBook(book);
        if (createdBook == null)
        {
            _logger.LogError("Failed to create book with title {title}", book.Title);
            return BadRequest();
        }
        Response.Headers.Append("X-API-Deprecated", "true");
        Response.Headers.Append("X-API-Deprecation-Date", "2026-12-31");
        return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
    }

    [HttpPut]
    public IActionResult UpdateBook([FromBody] BookDTO book)
    {
        _logger.LogInformation("Updating book with ID {id}", book.Id);
        var updatedBook = _services.UpdateBook(book);
        if (updatedBook == null)
        {
            _logger.LogWarning("Book with ID {id} not found for update", book.Id);
            return NotFound();
        }
        return Ok(updatedBook);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(long id)
    {
        _logger.LogInformation("Deleting book with ID {id}", id);
        _services.DeleteBook(id);
        _logger.LogDebug("Book with ID {id} deleted successfully", id);
        return NoContent();
    }
}
