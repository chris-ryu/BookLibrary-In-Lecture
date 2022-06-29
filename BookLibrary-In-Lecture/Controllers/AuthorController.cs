using BookLibrary_In_Lecture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary_In_Lecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpDelete("book-remove")] 
        public async Task<IActionResult> RemoveBook(int authorId, AuthorRemoveBookDTO authorRemoveBook)
        {
            var book = _context.Book.Find(authorRemoveBook.BookId);
            var author = await _context.Author
                        .Include(x => x.Books).SingleAsync(x => x.Id == authorId);
            if (author.Books.Remove(book))
            {
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpPost("add-book-fake")]
        public async Task<IActionResult> PostAddBookFake(AuthorAddBookDTO authorAddBookDTO) 
        {
            Book book = new Book
            {
                Title = authorAddBookDTO.Title,
                DateAdded = DateTime.UtcNow
            };


            var author = new Author { Id = authorAddBookDTO.AuthorId };
            _context.Attach(author);
            //var author = _context.Author.Find(authorAddBookDTO.AuthorId);
            author.Books.Add(book);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpPost("add-book")]
        public async Task<IActionResult> PostAddBook(AuthorAddBookDTO authorAddBookDTO) 
        {
            Book book = new Book
            {
                Title = authorAddBookDTO.Title,
                DateAdded = DateTime.UtcNow
            };

            var author = _context.Author.Find(authorAddBookDTO.AuthorId);
            author.Books.Add(book);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("author-book-publisher")]
        public async Task<IEnumerable<AuthorItemDTO>> GetAuthorBookPublisher()
        {
            var q = _context.Author.Select(a => new AuthorItemDTO
            {
                Id= a.Id,
                Name = a.Name,
                Books = a.Books.Select(b => new BookPublisher 
                { 
                    Title = b.Title, PublisherName = b.Publisher.Name
                }).ToList(),
            }).ToList();
            return q;
        }

        [HttpGet]
        public async Task<IEnumerable<AuthorItemDTO>> GetAuthors()
        {
            var q = _context.Author.Select(a => new AuthorItemDTO
            {
                Id= a.Id,
                Name = a.Name,
                BookCount = a.Books.Count,
            }).ToList();
            return q;
        }
    }
}
