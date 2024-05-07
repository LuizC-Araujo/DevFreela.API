using DevFreela.Application.Queries.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Application.Controllers
{
    [Route("api/skills")]
    public class SkillController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SkillController(IMediator mediator)
        {
             _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllSkillsQuery();

            var skills = await _mediator.Send(query);

            return Ok(skills);
        }
    }
}
