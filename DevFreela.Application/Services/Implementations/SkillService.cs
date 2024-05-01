using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;
        public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCS");
        }

        public List<SkillViewModel> GetAll()
        {

            using(var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, Desciption FROM Skills";

                return sqlConnection.Query<SkillViewModel>(script).ToList();
            }

            //var skills = _dbContext.Skills;

            //var skilldViewModel = skills
            //    .Select(s => new SkillViewModel(s.Id, s.Description))
            //    .ToList();

            //return skilldViewModel;

        }
    }
}
