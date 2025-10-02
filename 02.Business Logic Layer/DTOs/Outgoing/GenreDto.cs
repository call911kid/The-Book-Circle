using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace The_Book_Circle.DTOs
{
    public class GenreDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        
    }
}
