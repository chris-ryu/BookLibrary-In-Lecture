namespace BookLibrary_In_Lecture.Models
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
