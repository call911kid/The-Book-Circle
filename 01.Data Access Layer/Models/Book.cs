namespace The_Book_Circle.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string ISBN { get; set; } //International Standard Book Number
        public string Title { get; set; }
        public string? Subtitle { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public string Language { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int AuthorID { get; set; }
        public Author? Author { get; set; }
        public int PublisherID { get; set; }
        public Publisher? Publisher { get; set; }
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public ICollection<int> GenresIDs { get; set; } = new List<int>();


    }
}
