using DevFreela.Core.Enums;
using MediatR;

namespace DevFreela.API.Commands.ProjectCommands.FinishProject
{
    public class FinishProjectCommand : IRequest<Unit>
    {
        public FinishProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
