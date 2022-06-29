using BookLibrary_In_Lecture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary_In_Lecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PublisherController(AppDbContext context)
        {
            _context = context;
        }

        [HttpDelete("remove-book")]
        public async Task<IActionResult> DeleteBook(int publisherId, PublisherBookRemoveDTO publisherBookRemoveDTO)
        {
            var book = _context.Book.Find(publisherBookRemoveDTO.BookId);
            book.PublisherId = null;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherItemDTO>>> GetPublishers()
        {
            var q = _context.Publisher.Select(x => new PublisherItemDTO
            {
                Id = x.Id,
                Name = x.Name,
                Books = string.Join(", ", x.Books.Select(b => b.Title).ToArray())
            }).ToList();
            return q;
        }
    }
}
