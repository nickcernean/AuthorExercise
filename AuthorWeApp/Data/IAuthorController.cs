
using AuthorWeApp.Model;
namespace AuthorWeApp.Data;

public interface IAuthorController
{
    Task AddAuthor(Author author);
    Task<IList<Author>> GetAllAuthors();
}