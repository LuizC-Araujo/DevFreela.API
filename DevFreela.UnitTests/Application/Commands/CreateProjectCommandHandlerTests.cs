﻿using DevFreela.Application.Commands.ProjectCommands.CreateProject;
using DevFreela.Core.Entities;
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
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Title Test",
                Description = "Description Test",
                IdClient = 1,
                IdFreelancer = 2,
                TotalCost = 5000
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepositoryMock.Object);

            // act
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            // assert
            Assert.True(id >= 0);

            projectRepositoryMock.Verify(pr => pr.AddAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}
