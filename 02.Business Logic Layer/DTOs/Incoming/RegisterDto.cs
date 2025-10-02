using System.ComponentModel.DataAnnotations;

namespace The_Book_Circle._02.Business_Logic_Layer.DTOs
{
    public class RegisterDto
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


    }
}
