using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Project ASPNET Core 1", "Descrição do projeto", 1, 1, 5000),
                new Project("Project ASPNET Core 2", "Descrição do projeto", 1, 1, 10000),
                new Project("Project ASPNET Core 3", "Descrição do projeto", 1, 1, 20000)
            };

            Users = new List<User>
            {
                new User("Luiz Araujo", "la@gmail.com", new DateTime(1991, 1, 4)),
                new User("Robert C Martin", "la2@gmail.com", new DateTime(1950, 1, 4)),
                new User("Suelen R", "sr@gmail.com", new DateTime(1999, 1, 4))
            };

            Skills = new List<Skill>
            {
                new Skill("dotnet core"),
                new Skill("C#"),
                new Skill("SQL Server")
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }

    }
}
