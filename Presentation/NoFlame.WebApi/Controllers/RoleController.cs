using MediatR;
using Microsoft.AspNetCore.Mvc;
using NoFlame.RoleServices.Roles.CreateRole;
using NoFlame.RoleServices.Roles.DeleteRole;
using NoFlame.RoleServices.Roles.GetRoles;
using NoFlame.RoleServices.Roles.UpdateRole;
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
    public class RoleController : ControllerBase
    {
        private IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
     
        // POST api/<RoleController>
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            return Ok(await _mediator.Send(new CreateRoleCommand(roleName)));
        }
        [HttpPost("UpdateRole")]
        public async Task<IActionResult> UpdateRole(Guid id, string roleName)
        {
            return Ok(await _mediator.Send(new UpdateRoleCommand(id, roleName)));
        }
        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteRoleCommand(id)));
        }
        [HttpGet("GetRoleList")]
        public async Task<IActionResult> GetRoleList()
        {
            return Ok(await _mediator.Send(new GetRolesRequest()));
        }
    }
}
