using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using The_Book_Circle._02.Business_Logic_Layer.DTOs;

namespace The_Book_Circle.DTOs
{
    public class BookDto:BaseBookDto
    {
        public int ID { get; set; }
        public int AuthorID { get; set; }
        public int PublisherID { get; set; }
        public IEnumerable<int> GenresIDs { get; set; } = new List<int>();



    }
}
