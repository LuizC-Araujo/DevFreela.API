using DevFreela.API.Commands.UserCommands;
using DevFreela.API.Models;
using DevFreela.API.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var query = new GetUserByIdQuery(id);

            var user = _mediator.Send(query.Id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserCommand command)
        {
            var id = _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel loginModel)
        {
            return NoContent();
        }
    }
}
