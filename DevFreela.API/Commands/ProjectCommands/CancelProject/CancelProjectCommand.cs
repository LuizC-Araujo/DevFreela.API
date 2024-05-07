using DevFreela.Core.Enums;
using MediatR;

namespace DevFreela.API.Commands.ProjectCommands.CancelProject
{
    public class CancelProjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
