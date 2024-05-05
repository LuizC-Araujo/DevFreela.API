using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Commands.ProjectCommand
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;
        public StartProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public  async Task<int> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (project == null) return 0;

            project.Start();
            await _dbContext.SaveChangesAsync();

            return project.Id;
        }
    }
}
