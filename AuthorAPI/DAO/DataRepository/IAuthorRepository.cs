using AuthorAPI.DAO.Models;

namespace AuthorAPI.DAO.DataRepository;

public interface IAuthorRepository
{
    Task AddAuthor(DAO.Models.Author author);
    Task<IList<DAO.Models.Author>> GetAllAuthors();
}