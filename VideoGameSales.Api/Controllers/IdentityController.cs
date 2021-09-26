using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Core.Authentification.Command;
using VideoGameSales.Domain.ViewModels.Authentification;

namespace VideoGameSales.Api.Controllers
{
    public class IdentityController : Controller
    {
        private const string _base = "api/user";
        private readonly IMediator _mediator;

        public readonly UserManager<IdentityUser> _userManager;
        public IdentityController(IMediator mediator, UserManager<IdentityUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [HttpPost(_base)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationCommand request)
        {
            var identity = new UserRegistrationCommandHandler(_userManager);
            var token = new CancellationToken();
            var result = await identity.Handle(request,token);
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
            var identity = new UserLoginCommandHandler(_userManager);
            var token = new CancellationToken();
            var result = await identity.Handle(request,token);
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
