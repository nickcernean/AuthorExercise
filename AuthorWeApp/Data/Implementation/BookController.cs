using System.Net;
using System.Text;
using AuthorWeApp.Model;
using Newtonsoft.Json;

namespace AuthorWeApp.Data.Implementation;

public class BookController : IBookController
{
    private string uri = "https://localhost:5001";
    private readonly HttpClient client;
    private HttpClientHandler clientHandler;


    public BookController()
    {
        clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
        client = new HttpClient(clientHandler);
    }


    public async Task AddBook(Book book, int authorId)
    {
        string serializedBook = JsonConvert.SerializeObject(book);
        StringContent content = new StringContent(serializedBook, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync($"{uri}/Book/{authorId}", content);
        if (response.StatusCode == HttpStatusCode.Conflict)
        {
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
           // throw new Exception(response.Content.ToString());
        }
    }

    public async Task<IList<Book>> GetAllBooks()
    {
        IList<Book> books = new List<Book>();
        HttpResponseMessage responseMessage = await client.GetAsync(uri + "/Book");
        String reply = await responseMessage.Content.ReadAsStringAsync();
        books = JsonConvert.DeserializeObject<List<Book>>(reply);
        return books;
    }

    public async Task DeleteBook(int authorId, int isbn)
    {
        await client.DeleteAsync($"{uri}/Book/{authorId}/{isbn}");
    }
}