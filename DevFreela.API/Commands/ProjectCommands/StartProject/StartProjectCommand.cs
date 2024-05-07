using DevFreela.Core.Enums;
using MediatR;

namespace DevFreela.API.Commands.ProjectCommands.StartProject
{
    public class StartProjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
