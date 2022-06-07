﻿using System.ComponentModel.DataAnnotations;

namespace AuthorAPI.DAO.Models;

public class Author
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(15)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(15)]
    public string LastName { get; set; }
    public IList<Book>? Books { get; set; }
}