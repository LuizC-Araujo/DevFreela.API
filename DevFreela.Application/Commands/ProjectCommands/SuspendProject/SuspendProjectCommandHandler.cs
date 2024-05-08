using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.ProjectCommands.SuspendProject
{
    public class SuspendProjectCommandHandler : IRequestHandler<SuspendProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        public SuspendProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Unit> Handle(SuspendProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            if (project == null) return Unit.Value;

            project.Suspend();
            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
