using AuthorAPI.DAO.Models;

namespace AuthorAPI.DAO.DataRepository;

public interface IBookRepository
{
    Task AddBook(Book book, int authorId);
    Task<IList<Book>> GetAllBooks();
    Task RemoveBook(int authordId,int isbn);
}