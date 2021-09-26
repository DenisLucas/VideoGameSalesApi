using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using VideoGameSales.Core.Options;
using VideoGameSales.Domain.Entities.Authentification;

namespace VideoGameSales.Core.Authentification.Command
{
    public class UserLoginCommandHandler
    {

        public readonly UserManager<IdentityUser> _userManager;
        public readonly JwtSettings _jwtSettings;
        public UserLoginCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<AuthentificationResult> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Usermame);
            if (user == null)
            {
                return new AuthentificationResult
                {
                    Errors = new[] {"User does not exist"}
                };
            }

            var userhasPass = await _userManager.CheckPasswordAsync(user,request.Password);

            if (!userhasPass)
            {
                return new AuthentificationResult
                {
                    Errors = new[] {"Password or username invalid"}
                };
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims: new []
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    
                    new Claim("Id", user.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthentificationResult
            {
                Succes = true,
                Token = tokenHandler.WriteToken(token)
            };
        }
        
    }
}
