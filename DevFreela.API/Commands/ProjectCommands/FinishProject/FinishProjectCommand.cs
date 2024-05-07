using DevFreela.Core.Enums;
using MediatR;

namespace DevFreela.API.Commands.ProjectCommands.FinishProject
{
    public class FinishProjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
