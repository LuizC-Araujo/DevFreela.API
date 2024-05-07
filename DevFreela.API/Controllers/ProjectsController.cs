using DevFreela.API.Commands.ProjectCommands.CancelProject;
using DevFreela.API.Commands.ProjectCommands.CreateComment;
using DevFreela.API.Commands.ProjectCommands.CreateProject;
using DevFreela.API.Commands.ProjectCommands.FinishProject;
using DevFreela.API.Commands.ProjectCommands.StartProject;
using DevFreela.API.Commands.ProjectCommands.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
     
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;
        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAll(string query)
        {
            var projects = _projectService.GetAll(query);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);

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

        [HttpPut]
        public IActionResult Update([FromBody] UpdateProjectCommand command)
        {
            if (command.Description.Length > 200)
                return BadRequest();

            _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("cancel")]
        public async Task<IActionResult> Cancel(CancelProjectCommand command) 
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/1/comments
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command) 
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/start
        [HttpPut("start")]
        public async Task<IActionResult> Start([FromBody] StartProjectCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/finish
        [HttpPut("finish")]
        public async Task<IActionResult> Finish([FromBody] FinishProjectCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
