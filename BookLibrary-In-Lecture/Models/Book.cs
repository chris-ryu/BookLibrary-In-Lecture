using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary_In_Lecture.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsRead { get; set; }
        public int? Rate { get; set; }
        public string? Genre { get; set; }
        public string? CoverUrl { get; set; }

        public virtual int? PublisherId { get; set; }
        //[ForeignKey("PublisherId")]
        public virtual Publisher Publisher { get; set; }

        public virtual List<Author> Authors { get; set; }
    }
}
