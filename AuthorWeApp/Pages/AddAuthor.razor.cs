using AuthorWeApp.Model;
using Microsoft.AspNetCore.Components;

namespace AuthorWeApp.Pages;

public partial class AddAuthor :ComponentBase
{
    [Parameter] public int AuthorId { get; set; }

    private Author _authorToAdd;

    protected override async Task OnInitializedAsync()
    {
        _authorToAdd = new Author();
    }


    private async Task AddAuthorAsync()
    {
       
        await _authorController.AddAuthor(_authorToAdd);
        _authorToAdd = new Author();
         _navigationManager.NavigateTo($"/");
    }   
}