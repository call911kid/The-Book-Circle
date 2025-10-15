using The_Book_Circle._02.Business_Logic_Layer.DTOs;
using The_Book_Circle.Errors;

namespace The_Book_Circle._02.Business_Logic_Layer.Interfaces
{
    public interface IAccountService
    {
        public Task<AuthenticationDto> RegisterAsync(RegisterDto registerDto);
        public Task<AuthenticationDto> LoginAsync(LoginDto loginDto);
        public Task<bool> LogoutAsync(string token);
        public Task<AuthenticationDto> RefreshTokenAsync(string token);
    }
}
