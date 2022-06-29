using BookLibrary_In_Lecture.Controllers;

namespace BookLibrary_In_Lecture.Models
{
    public class AuthorItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BookCount { get; set; }
        public List<BookPublisher> Books { get; set; }
    }
}