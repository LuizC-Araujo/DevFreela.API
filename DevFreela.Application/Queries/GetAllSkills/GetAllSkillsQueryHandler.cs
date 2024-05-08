using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillDTO>>
    {
        private readonly ISkillRepository _skillRepository;
        public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<SkillDTO>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            return await _skillRepository.GetAllAsync();
        }

        //using EF Core
        //private readonly DevFreelaDbContext _dbContext;
        //public GetAllSkillsQueryHandler(DevFreelaDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        //{
        //    var skills = _dbContext.Skills;

        //    var skilldViewModel = await skills
        //        .Select(s => new SkillViewModel(s.Id, s.Description))
        //        .ToListAsync();

        //    return skilldViewModel;
        //}
    }
}
