using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using The_Book_Circle._01.Data_Access_Layer.Models;
using The_Book_Circle._02.Business_Logic_Layer.DTOs;
using The_Book_Circle._02.Business_Logic_Layer.Exceptions;
using The_Book_Circle._02.Business_Logic_Layer.Interfaces;
using The_Book_Circle.Errors;

namespace The_Book_Circle._02.Business_Logic_Layer.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public AccountService(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<ServiceResult<AuthenticationDto>> RegisterAsync(RegisterDto registerDto)
        {
            if (await _userManager.FindByEmailAsync(registerDto.Email) != null)
                throw new ConflictException("Email is already registered");

            if (await _userManager.FindByNameAsync(registerDto.Username) != null)
                throw new ConflictException("Username is already taken");


            var user = new User  //use AutoMapper here B3deen
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                UserName = registerDto.Username,
                Email = registerDto.Email,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join("\n", result.Errors.Select(e => e.Description));
                throw new BadRequestException(errors);
            }

            //add role to user (optional)
            await _userManager.AddToRoleAsync(user, "User");

            var jwtToken = await _tokenService.CreateJwtToken(user);

            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshTokens?.Add(refreshToken);
            await _userManager.UpdateAsync(user);

            return ServiceResult<AuthenticationDto>.Success(
                new AuthenticationDto
                {
                    IsAuthenticated = true,
                    Email = user.Email,
                    Username = user.UserName,
                    Roles = new List<string> { "User" },
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    ExpiresOn = jwtToken.ValidTo,
                    RefreshToken = refreshToken.Token,
                    RefreshTokenExpiresOn = refreshToken.ExpiresOn

                }
            );
        }

        public async Task<ServiceResult<AuthenticationDto>> LoginAsync(LoginDto loginDto)
        {


            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                throw new UnauthorizedException("Invalid email or password");
            }

            var jwtToken = await _tokenService.CreateJwtToken(user);
            var roles = await _userManager.GetRolesAsync(user);

            var authenticationDto = new AuthenticationDto
            {
                IsAuthenticated = true,
                Email = user.Email,
                Username = user.UserName,
                Roles = roles.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                ExpiresOn = jwtToken.ValidTo
            };

            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.First(t => t.IsActive);
                authenticationDto.RefreshToken = activeRefreshToken.Token;
                authenticationDto.RefreshTokenExpiresOn = activeRefreshToken.ExpiresOn;
            }
            else
            {
                var refreshToken = _tokenService.GenerateRefreshToken();
                user.RefreshTokens.Add(refreshToken);
                await _userManager.UpdateAsync(user);
                authenticationDto.RefreshToken = refreshToken.Token;
                authenticationDto.RefreshTokenExpiresOn = refreshToken.ExpiresOn;
            }

            return ServiceResult<AuthenticationDto>.Success(authenticationDto);
        }

        public async Task<ServiceResult> LogoutAsync(string token)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token))
                ?? throw new UnauthorizedException("Invalid token");
            

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);
            if (!refreshToken.IsActive)
            {
                throw new UnauthorizedException("Inactive token");
                
            }

            // Revoke the refresh token
            refreshToken.RevokedOn = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            return ServiceResult.Success();
        }
        public async Task<ServiceResult<AuthenticationDto>> RefreshTokenAsync(string token)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token))
                ?? throw new UnauthorizedException("Invalid token");


            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);
            if (!refreshToken.IsActive)
            {
                throw new UnauthorizedException("Inactive token");

            }
            // Revoke the old refresh token
            refreshToken.RevokedOn = DateTime.UtcNow;

            // Generate a new refresh token and add it to the user
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            await _userManager.UpdateAsync(user);

            // Create a new JWT
            var jwtToken = await _tokenService.CreateJwtToken(user);
            var roles = await _userManager.GetRolesAsync(user);

            return ServiceResult<AuthenticationDto>.Success(
                new AuthenticationDto
                {
                    IsAuthenticated = true,
                    Email = user.Email,
                    Username = user.UserName,
                    Roles = roles.ToList(),
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    ExpiresOn = jwtToken.ValidTo,
                    RefreshToken = newRefreshToken.Token
                }
            );
        }



    }
}
