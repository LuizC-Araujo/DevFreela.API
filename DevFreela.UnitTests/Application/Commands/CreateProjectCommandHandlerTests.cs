using DevFreela.Application.Commands.ProjectCommands.CreateProject;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputaDataIsOk_Executed_ReturnProjectId()
        {
            // arrange
            var projectRepository = new Mock<IProjectRepository>();

            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Title Test",
                Description = "Description Test",
                IdClient = 1,
                IdFreelancer = 2,
                TotalCost = 5000
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepository.Object);

            // act
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            // assert
        }
    }
}
