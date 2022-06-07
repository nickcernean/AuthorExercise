
using AuthorWeApp.Model;

namespace AuthorWeApp.Data;

public interface IBookController
{
    Task AddBook(AuthorWeApp.Model.Book book,int authorId);
    Task<IList<Book>> GetAllBooks();
    Task DeleteBook(int authorId,int isbn);
}