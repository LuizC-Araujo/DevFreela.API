using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.ProjectCommands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        public CreateProjectCommandHandler(IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;

        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {

            var project = new Project(request.Title, request.Description, request.ClientId, request.TotalCost);

            await _projectRepository.AddAsync(project);

            return project.Id;
        }
    }
}
