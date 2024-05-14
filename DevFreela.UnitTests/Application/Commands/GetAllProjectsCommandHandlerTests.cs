using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System.Net.WebSockets;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            // arrange
            var projects = new List<Project>
            { 
                new("Nome do Teste 1", "Descrição 1", 1, 2, 10000),
                new("Nome do Teste 2", "Descrição 3", 1, 2, 20000),
                new("Nome do Teste 3", "Descrição 4", 1, 2, 30000)
            };

            var projectRepository = new Mock<IProjectRepository>();
            projectRepository.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery();
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepository.Object);

            //act
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            //assert

        }
    }
}
