using AuthorAPI.DataAccess;
using AuthorAPI.DAO.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorAPI.DAO.DataRepository.Implementation;

public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public AuthorRepository(LibraryDbContext libraryDbContext)
    {
        this._libraryDbContext = libraryDbContext;
    }

    public async Task AddAuthor(DAO.Models.Author author)
    {
      
        await _libraryDbContext.AddAsync(author);
        await _libraryDbContext.SaveChangesAsync();
    }

    public async Task<IList<DAO.Models.Author>> GetAllAuthors()
    {
        return await _libraryDbContext.Authors.Include(b => b.Books).ToListAsync();
    }
}