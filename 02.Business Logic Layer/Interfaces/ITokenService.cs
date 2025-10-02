using System.IdentityModel.Tokens.Jwt;
using The_Book_Circle._01.Data_Access_Layer.Models;

namespace The_Book_Circle._02.Business_Logic_Layer.Interfaces
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateJwtToken(User user);

        RefreshToken GenerateRefreshToken();
    }
}
