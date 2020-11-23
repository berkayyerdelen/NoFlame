using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoFlame.WebApi.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<EventController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

      
    }
}
