using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.ProjectCommands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        public UpdateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            request.Title ??= project.Title;
            request.Description ??= project.Description;  
            request.TotalCost ??= project.TotalCost;
            

            project.Update(request.Title, request.Description, (decimal) request.TotalCost);

            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
