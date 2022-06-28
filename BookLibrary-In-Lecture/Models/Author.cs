namespace BookLibrary_In_Lecture.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
