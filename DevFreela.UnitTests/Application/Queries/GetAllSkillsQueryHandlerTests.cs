using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllSkillsQueryHandlerTests
    {
        [Fact]
        public async Task FiveSkillsExist_Executed_ReturnFiveSkillDtos()
        {
            // arrange
            var skills = new List<Skill> 
            {
                new("skill 1"),
                new("skill 2"),
                new("skill 3"),
                new("skill 4"),
                new("skill 5")
            };

            var skillRepositoryMock = new Mock<ISkillRepository>();
            skillRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(skills);

            var getAllSkillsQuery = new GetAllSkillsQuery();
            var getAllSkillsQueryHandler = new GetAllSkillsQueryHandler(skillRepositoryMock.Object);

            //act
            var skillList = await getAllSkillsQueryHandler.Handle(getAllSkillsQuery, new CancellationToken());

            //assert
            Assert.NotNull(skillList);
            Assert.NotEmpty(skillList);
            Assert.Equal(skills.Count, skillList.Count);
        }
    }
}
