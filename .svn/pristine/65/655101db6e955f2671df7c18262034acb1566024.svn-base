using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PIPTWeb.Shared
{
    public interface IAuthenticateService
    {
        Task<SecUsers> IsAuthenticatedUsers(LoginRequest loginRequest);
        string GenerateToken(SecUsers user);
    }

    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserManagementService _userManagmentService;
        private readonly TokenManagement _tokenManagement;

        public AuthenticateService(IUserManagementService userManagmentService, IOptionsSnapshot<TokenManagement> tokenManagement)
        {
            _userManagmentService = userManagmentService;
            _tokenManagement = tokenManagement.Value;
        }

        public string GenerateToken(SecUsers user)
        {
            string token = string.Empty;
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("IsAdmin", user.IsAdmin.ToString()),
                new Claim("FullName", user.FirstName + " " + user.LastName)
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            var jwtToken = new JwtSecurityToken(
                _tokenManagement.Issuer,
                _tokenManagement.Audience,
                claims,
                expires: DateTime.UtcNow.AddDays(_tokenManagement.AccessExpiration),
                signingCredentials : credentials
                );
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }

        public async Task<SecUsers> IsAuthenticatedUsers(LoginRequest loginRequest)
        {
            SecUsers user = await _userManagmentService.IsValidUsers(loginRequest.UserName, loginRequest.Password);
            return user;
        }
    }
}
