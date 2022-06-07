using AuthorAPI.DAO.DataRepository;
using AuthorAPI.DAO.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorAPI.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorController(IAuthorRepository authorRepository)
    {
        this._authorRepository = authorRepository;
    }

    [HttpPost]
    public async Task<ActionResult> AddAuthor([FromBody] API.Model.AuthorAPI author)
    {
        try
        {
            DAO.Models.Author newAuthor = new Author()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Books = null
            };
            await _authorRepository.AddAuthor(newAuthor);
            Console.WriteLine("Executed successfully");
            return Ok();
        }
        catch (HttpRequestException e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IList<Author>>> GetAllAuthors()
    {
        try
        {
            IList<Author> authors = await _authorRepository.GetAllAuthors();
            Console.WriteLine("Executed successfully");
            return Ok(authors);
        }
        catch (DirectoryNotFoundException e)
        {
            return StatusCode(500, e.Message);
        }
    }
}