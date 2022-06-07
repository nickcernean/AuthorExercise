using System.Text;
using AuthorWeApp.Model;
using Newtonsoft.Json;

namespace AuthorWeApp.Data.Implementation;

public class AuthorController : IAuthorController
{
    private string uri = "https://localhost:5001";
    private readonly HttpClient client;
    private HttpClientHandler clientHandler;


    public AuthorController()
    {
        clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
        client = new HttpClient(clientHandler);
    }

    public async Task AddAuthor(Author author)
    {
        string serializedAuthor = JsonConvert.SerializeObject(author);
        StringContent content = new StringContent(serializedAuthor, Encoding.UTF8, "application/json");
        await client.PostAsync($"{uri}/Author", content);
    }

    public async Task<IList<Author>> GetAllAuthors()
    {
        IList<Author> authors = new List<Author>();
        HttpResponseMessage responseMessage = await client.GetAsync(uri + "/Author");
        String reply = await responseMessage.Content.ReadAsStringAsync();
        authors = JsonConvert.DeserializeObject<List<Author>>(reply);
        return authors;
    }
}