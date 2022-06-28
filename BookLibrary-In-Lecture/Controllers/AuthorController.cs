using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
