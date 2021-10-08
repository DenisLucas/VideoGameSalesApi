using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Core.Authentification.Command;
using VideoGameSales.Core.Options;
using VideoGameSales.Domain.ViewModels.Authentification;

namespace VideoGameSales.Api.Controllers
{
    public class IdentityController : Controller
    {
        private const string _base = "api/user";
        private readonly IMediator _mediator;

        public readonly UserManager<IdentityUser> _userManager;
        public readonly JwtSettings _jwtSettings;
        public IdentityController(IMediator mediator, UserManager<IdentityUser> userManager, JwtSettings jwtSettings)
        {
            _mediator = mediator;
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }

        [HttpPost(_base)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationCommand request)
        {
            var identity = new UserRegistrationCommandHandler(_userManager,_jwtSettings);
            var result = await identity.Handle(request);
            if (!result.Succes)
            {
                return Ok(new AuthentificationFailViewModel
                {
                    Errors = result.Errors
                });
            }
            return Ok(new AuthentificationViewModel
            {
                Token = result.Token
            });
        }
        [HttpPost(_base + "/login")]
        public async Task<IActionResult> Login([FromBody] UserLoginCommand request)
        {
            var identity = new UserLoginCommandHandler(_userManager,_jwtSettings);
            var result = await identity.Handle(request);
            if (!result.Succes)
            {
                return Ok(new AuthentificationFailViewModel
                {
                    Errors = result.Errors
                });
            }
            return Ok(new AuthentificationViewModel
            {
                Token = result.Token
            });
        }
    }
}
