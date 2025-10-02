using Microsoft.AspNetCore.Identity;

namespace The_Book_Circle._01.Data_Access_Layer.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<RefreshToken>? RefreshTokens { get; set; }

    }
}
