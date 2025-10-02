using System.ComponentModel.DataAnnotations;

namespace The_Book_Circle._02.Business_Logic_Layer.DTOs
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
