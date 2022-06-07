﻿using System.ComponentModel.DataAnnotations;

namespace AuthorWeApp.Model;

public class Author
{
  
    public int Id { get; set; }
    [Required]
    [MaxLength(15)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(15)]
    public string LastName { get; set; }
    public IList<Book>? Books { get; set; }
}
