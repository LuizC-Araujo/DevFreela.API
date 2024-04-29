using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Services.Interfaces;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;
        public SkillService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SkillViewModel> GetAll()
        {
            var skills = _dbContext.Skills;

            var skilldViewModel = skills
                .Select(s => new SkillViewModel(s.Id, s.Description))
                .ToList();

            return skilldViewModel;
        }
    }
}
