using System.ComponentModel.DataAnnotations;
using The_Book_Circle._02.Business_Logic_Layer.Validators;
using The_Book_Circle.DTOs;

namespace The_Book_Circle._02.Business_Logic_Layer.DTOs.Incoming
{
    public class CreateBookDto: BaseBookDto
    {
        public int AuthorID { get; set; }
        public int PublisherID { get; set; }
        public IEnumerable<int> GenresIDs { get; set; } = new List<int>();

    }
}
