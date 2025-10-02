using The_Book_Circle._02.Business_Logic_Layer.DTOs;
using The_Book_Circle.Errors;

namespace The_Book_Circle._02.Business_Logic_Layer.Interfaces
{
    public interface IAccountService
    {
        public Task<ServiceResult<AuthenticationDto>> RegisterAsync(RegisterDto registerDto);
        public Task<ServiceResult<AuthenticationDto>> LoginAsync(LoginDto loginDto);
        public Task<ServiceResult> LogoutAsync(string token);
        public Task<ServiceResult<AuthenticationDto>> RefreshTokenAsync(string token);
    }
}
