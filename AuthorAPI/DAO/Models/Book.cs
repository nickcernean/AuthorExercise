using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorAPI.DAO.Models;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Required]
    public int ISBN { get; set; }
    [Required] [MaxLength(40)] public string Title { get; set; }
    public int PublicationYear { get; set; }
    public int NumOfPages { get; set; }
    public string Genre { get; set; }
}