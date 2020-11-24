using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoFlame.Domain.Repository;
using NoFlame.UserServices.User.Auth.Login;
using NoFlame.UserServices.User.Auth.Logout;
using NoFlame.UserServices.User.Auth.RefreshToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoFlame.WebApi.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public AuthController(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var loginResult = await _mediator.Send(request);
            return Ok(loginResult);
        }
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogOutRequest request, CancellationToken ct)
        {
            return Ok(await _mediator.Send(request, ct));
        }
        [HttpGet("authenticated")]
        [Authorize]
        public string Authenticated() {
            return String.Format("Authenticated - {0}", User.Identity.Name); }

        [HttpGet("Admin")]
        [Authorize(Roles = "Admin")]
        public string Admin()
        {
            return "You're admin";
        }
        [HttpPost("RefreshToken")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest request, CancellationToken ct)
        {
            return Ok(await _mediator.Send(request, ct));
        }
        [HttpGet("Random")]
        [Authorize(Roles ="Random")]
        public string Random()
        {
            return "You're Random";
        }
    }
}
