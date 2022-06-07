using AuthorAPI.DataAccess;
using AuthorAPI.DAO.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorAPI.DAO.DataRepository.Implementation;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public BookRepository(LibraryDbContext libraryDbContext)
    {
        this._libraryDbContext = libraryDbContext;
    }

    public async Task AddBook(Book book, int authorId)
    {
        try
        {
            _libraryDbContext.Authors.Include(b => b.Books).FirstOrDefault(a => a.Id.Equals(authorId)).Books.Add(book);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        await _libraryDbContext.SaveChangesAsync();
    }

    public async Task<IList<DAO.Models.Book>> GetAllBooks()
    {
        return await _libraryDbContext.Authors.SelectMany(b => b.Books).ToListAsync();
    }

    public async Task RemoveBook(int authorId, int isbn)
    {
        Book book;
        try
        {
            book = _libraryDbContext.Authors.Include(b => b.Books).FirstOrDefault(a => a.Id.Equals(authorId)).Books
                .FirstOrDefault(b => b.ISBN.Equals(isbn));
            Console.WriteLine(book.ISBN);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        _libraryDbContext.Authors.Include(b => b.Books).FirstOrDefault(a => a.Id.Equals(authorId)).Books
            .Remove(book);
        _libraryDbContext.SaveChanges();
    }
}