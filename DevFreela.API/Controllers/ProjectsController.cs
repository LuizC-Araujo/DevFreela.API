using DevFreela.API.Commands.ProjectCommands.CancelProject;
using DevFreela.API.Commands.ProjectCommands.CreateComment;
using DevFreela.API.Commands.ProjectCommands.CreateProject;
using DevFreela.API.Commands.ProjectCommands.FinishProject;
using DevFreela.API.Commands.ProjectCommands.StartProject;
using DevFreela.API.Commands.ProjectCommands.UpdateProject;
using DevFreela.API.Queries.GetAllProjects;
using DevFreela.API.Queries.GetProjectById;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var query = new GetAllProjectsQuery();

            var projects = _mediator.Send(query);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var query = new GetProjectByIdQuery(id);

            var project = _mediator.Send(query.Id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command) 
        { 
            if (command.Title.Length > 50)
                return BadRequest();

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id =  id }, command);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateProjectCommand command)
        {
            if (command.Description.Length > 200)
                return BadRequest();

            _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Cancel(int id) 
        {
            var command = new CancelProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command) 
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/1/start
        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/1/finish
        [HttpPut("{1}finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
