using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using The_Book_Circle._02.Business_Logic_Layer.DTOs.BaseDtos;

namespace The_Book_Circle.DTOs
{
    public class PublisherDto:BasePublisherDto
    {
        public int ID { get; set; }
        
    }
}
