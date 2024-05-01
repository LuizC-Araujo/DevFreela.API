using DevFreela.Core.Entities;
using DevFreela.Application.ViewModels;
using DevFreela.Application.InputModels;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Services.Interfaces;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewUserInputModel inputModel)
        {
            var newUser = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);

            _dbContext.Users.Add(newUser);

            _dbContext.SaveChanges();

            return newUser.Id;
        }

        public UserViewModel GetUserById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null) return null;

            var userViewModel = new UserViewModel(user.FullName, user.Email);

            return userViewModel;
        }
    }
}
