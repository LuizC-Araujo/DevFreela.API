using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Commands.ProjectCommand
{
    public class CancelProjectCommandHandler : IRequestHandler<CancelProjectCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;
        public CancelProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CancelProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (project == null) return 0;

            project.Cancel();
            await _dbContext.SaveChangesAsync();

            return project.Id;
        }
    }
}
