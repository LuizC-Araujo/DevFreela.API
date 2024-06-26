﻿using Dapper;
using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly string _connectionString;
        public SkillRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            using (var sqlConnetion = new SqlConnection(_connectionString))
            {
                sqlConnetion.Open();
                var script = "SELECT Id, Description FROM Skills";
                var skills = await sqlConnetion.QueryAsync<Skill>(script);

                return skills.ToList();
            }
        }
    }
}
