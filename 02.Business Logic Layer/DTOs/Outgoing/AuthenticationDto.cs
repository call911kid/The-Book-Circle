using System.Text.Json.Serialization;

namespace The_Book_Circle._02.Business_Logic_Layer.DTOs
{
    public class AuthenticationDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsAuthenticated { get; set; } = false;
        public List<string> Roles { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public DateTime? ExpiresOn { get; set; }
        [JsonIgnore]
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiresOn { get; set; }

    }
}
