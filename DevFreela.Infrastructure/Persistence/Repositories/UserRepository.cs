using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserRepository(DevFreelaDbContext dbContext) => _dbContext = dbContext;

        public async Task AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
            => await _dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        

        public async Task<User> GetUserByIdAsync(int id)
            => await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
    }
}
