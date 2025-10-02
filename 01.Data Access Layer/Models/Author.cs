namespace The_Book_Circle.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Biography { get; set; }
        public string? PhotoUrl { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
