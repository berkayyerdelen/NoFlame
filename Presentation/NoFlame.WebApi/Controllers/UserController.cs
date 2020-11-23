using MediatR;
using Microsoft.AspNetCore.Mvc;
using NoFlame.UserServices.User.CreateUser;
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
    public class UserController : ControllerBase
    {
        public IMediator _mediator{ get; set; }

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserCommand request, CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }          
            return Ok(await _mediator.Send(request));
        }
        
     

    }
}
