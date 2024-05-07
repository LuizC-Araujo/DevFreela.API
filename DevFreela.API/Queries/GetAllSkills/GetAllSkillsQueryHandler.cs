using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.API.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {

        //using dapper
        //private readonly string _connectionString;
        //public GetAllSkillsQueryHandler(IConfiguration configuration)
        //{
        //    _connectionString = configuration.GetConnectionString("DevFreelaCs");
        //}

        //public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        //{
        //    using (var sqlConnection = new SqlConnection(_connectionString))
        //    {
        //        sqlConnection.Open();

        //        var script = "SELECT Id, Desciption FROM Skills";

        //        var skills = await sqlConnection.QueryAsync<SkillViewModel>(script);

        //        return skills.ToList();
        //    }
        //}

        //using EF Core
        private readonly DevFreelaDbContext _dbContext;
        public GetAllSkillsQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = _dbContext.Skills;

            var skilldViewModel = skills
                .Select(s => new SkillViewModel(s.Id, s.Description))
                .ToList();

            return skilldViewModel;
        }
    }
}
