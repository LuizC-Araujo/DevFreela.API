using DevFreela.Core.Entities;
using DevFreela.Application.ViewModels;
using DevFreela.Application.InputModels;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Services.Interfaces;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);
            
            _dbContext.Projects.Add(project);

            return project.Id;
        }

        public void CreateComment(CreateCommandInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);
            
            _dbContext.Comments.Add(comment);
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);

            project.Cancel();
        }

        public void Finished(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Finish();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = projects
                .Select(x => new ProjectViewModel(x.Id, x.Title, x.CreatedAt))
                .ToList();

            return projectsViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            var projectDetailViewModel = new ProjectDetailsViewModel(
                project.Id, 
                project.Title, 
                project.Description, 
                project.TotalCost, 
                project.StartedAt, 
                project.FinishedAt
                );

            return projectDetailViewModel;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project?.Start();
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            project?.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
        }
    }
}
