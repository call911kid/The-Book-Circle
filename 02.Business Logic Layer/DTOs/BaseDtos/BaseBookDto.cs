namespace The_Book_Circle._02.Business_Logic_Layer.DTOs
{
    public class BaseBookDto
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public string Language { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime PublicationDate { get; set; } 

    }
}
