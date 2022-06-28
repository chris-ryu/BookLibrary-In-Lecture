using Microsoft.EntityFrameworkCore;
using BookLibrary_In_Lecture.Models;

namespace BookLibrary_In_Lecture
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }
        public DbSet<Book> Book { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Author> Author { get; set; }

    }
}
