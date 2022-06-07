using AuthorAPI.DAO.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorAPI.DataAccess;

public class LibraryDbContext :DbContext
{
    public DbSet<Author> Authors { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source = D:/Semester3/DNP3Y-ReExam/ExamA20_304190/AuthorAPI/Author.db");
    }

}