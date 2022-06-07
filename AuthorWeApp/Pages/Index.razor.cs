using AuthorWeApp.Model;
using Blazorise.Extensions;
using Microsoft.AspNetCore.Components;

namespace AuthorWeApp.Pages;

public partial class Index : ComponentBase
{
    private IList<Author> allAuthors = new List<Author>();
    [Parameter] public EventCallback<bool> CloseEventCallback { get; set; }
    public string Filter { get; set; }

    protected override async Task OnInitializedAsync()
    {
        allAuthors = await _authorController.GetAllAuthors();
    }

    public async void DeleteBook(int authorId, int isbn)
    {
        await _bookController.DeleteBook(authorId, isbn);
        StateHasChanged();
    }

    public bool IsVisible(Author author, Book book)
    {
        if (string.IsNullOrEmpty(Filter))
            return true;
        if (book.Title.StartsWith(Filter))
            return true;
        if (author.FirstName.StartsWith(Filter))
            return true;
        return false;
    }
}