using DevFreela.Application.Queries.GetUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetUserByIdQueryHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnUserViewModel()
        {
            //arrange
            var userRepositoryMock = new Mock<IUserRepository>();

            var createUser = new User("Sujeito Teste", "sujeito@email.com", DateTime.Now, "Senha", "client");

            var getUserByIdQuery = new GetUserByIdQuery(createUser.Id);
            var getUserByIdQueryHandler = new GetUserByIdQueryHandler(userRepositoryMock.Object);

            //act
            var userViewModel = await getUserByIdQueryHandler.Handle(getUserByIdQuery, new CancellationToken());

            //assert
            Assert.NotNull(userViewModel);

            userRepositoryMock.Verify(p => p.GetUserByIdAsync(createUser.Id).Result, Times.Once);  
        }
    }
}
