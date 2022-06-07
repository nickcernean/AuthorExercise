using AuthorWeApp.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.DataProtection;

namespace AuthorWeApp.Pages;

public partial class AddBook : ComponentBase
{
    [Parameter] public int AuthorId { get; set; }
    private DataAnnotationsValidator dataAnnotationsValidator { get; set; }
    private Book bookToAdd;
    private IList<Author> Authors = new List<Author>();
    private string authorFirstName;
    private string authorLastName;

    protected override async Task OnInitializedAsync()
    {
        bookToAdd = new Book();
        Authors = await _authorController.GetAllAuthors();
    }


    private async Task AddBookAsync()
    {
        try
        {
            await _bookController.AddBook(bookToAdd, AuthorId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        bookToAdd = new Book();
        _navigationManager.NavigateTo($"/");
    }

    private void SetAuthor(int authorId)
    {
        AuthorId = authorId;
        authorFirstName = Authors.FirstOrDefault(s => s.Id == AuthorId).FirstName;
        authorLastName = Authors.FirstOrDefault(s => s.Id == AuthorId).LastName;
    }
}