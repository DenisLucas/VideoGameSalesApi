using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using VideoGameSales.Core.Options;
using VideoGameSales.Domain.Entities.Authentification;

namespace VideoGameSales.Core.Authentification.Command
{
    public class UserRegistrationCommandHandler
    {
        public readonly UserManager<IdentityUser> _userManager;
        public readonly JwtSettings _jwtSettings;
        public UserRegistrationCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<AuthentificationResult> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
        {
            
            var userExist = await _userManager.FindByNameAsync(request.Usermame);
            if (userExist != null)
            {
                return new AuthentificationResult
                    {
                      Errors = new []{"User with this Username adress already exist"}  
                    };
            }
            var newUser = new IdentityUser
                {
                    UserName = request.Usermame,
                };
            var createdUser = await _userManager.CreateAsync(newUser, request.Password);

            if (!createdUser.Succeeded)
            {
                return new AuthentificationResult 
                {
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims: new []
                {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    
                    new Claim("Id", newUser.Id)
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
