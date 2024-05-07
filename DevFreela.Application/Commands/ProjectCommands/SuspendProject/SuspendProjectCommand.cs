using MediatR;

namespace DevFreela.Application.Commands.ProjectCommands.SuspendProject
{
    public class SuspendProjectCommand : IRequest<Unit>
    {
        public int Id { get; private set; }

        public SuspendProjectCommand(int id)
        {
            Id = id;
        }
    }
}
