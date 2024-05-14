using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsQueryHandlerTests
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

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery();
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            //act
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            //assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
