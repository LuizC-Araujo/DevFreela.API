using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Commands.ProjectCommand
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;
        public FinishProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (project == null) return 0;

            project.Finish();
            await _dbContext.SaveChangesAsync();

            return project.Id;
        }
    }
}
