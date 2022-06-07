using AuthorAPI.DAO.DataRepository;
using AuthorAPI.DAO.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BookController(IBookRepository bookRepository)
    {
        this._bookRepository = bookRepository;
    }

    [HttpPost]
    [Route("{authorId:int}")]
    public async Task<ActionResult> AddBook([FromBody] Book book, [FromRoute] int authorId)
    {
        try
        {
            await _bookRepository.AddBook(book, authorId);
            Console.WriteLine("Executed successfully");
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(409, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IList<Book>>> GetBooks()
    {
        try
        {
            IList<Book > authors = await _bookRepository.GetAllBooks();
            Console.WriteLine("Executed successfully");
            return Ok(authors);

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpDelete]
    [Route("{authorId:int}/{ISBN:int}")]
    public async Task<ActionResult> DeleteBook([FromRoute] int authorId,[FromRoute]int  isbn)
    {
        try
        {
             await _bookRepository.RemoveBook(authorId,isbn);
            Console.WriteLine("Executed successfully");
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}