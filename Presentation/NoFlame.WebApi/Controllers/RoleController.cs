using MediatR;
using Microsoft.AspNetCore.Mvc;
using NoFlame.RoleServices.Roles.CreateRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoFlame.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
     
        // POST api/<RoleController>
        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            return Ok(await _mediator.Send(new CreateRoleCommand(roleName)));
        }
    }
}
