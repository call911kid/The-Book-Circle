namespace The_Book_Circle.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();


    }
}
