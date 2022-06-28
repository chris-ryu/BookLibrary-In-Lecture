using BookLibrary_In_Lecture.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BookLibrary_In_Lecture.Seeds
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var appDbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (!appDbContext.Publisher.Any()) {
                    var filePath = Path.Combine("Seeds", "publisher.json");
                    var publishers = JsonConvert.DeserializeObject<List<Publisher>>(File.ReadAllText(filePath))!;
                    appDbContext.Publisher.AddRange(publishers);
                    appDbContext.SaveChanges();
                }

                if (!appDbContext.Book.Any())
                {
                    var bookFilePath = Path.Combine("Seeds", "book.json");
                    var books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(bookFilePath))!;
                    appDbContext.Book.AddRange(books);
                    appDbContext.SaveChanges();
                }

                if (!appDbContext.Author.Any())
                {
                    var authorFilePath = Path.Combine("Seeds", "authors.json");
                    var authors = JsonConvert.DeserializeObject<List<Author>>(File.ReadAllText(authorFilePath))!;
                    appDbContext.Author.AddRange(authors);
                    appDbContext.SaveChanges();
                }
            }
        }
    }
}
