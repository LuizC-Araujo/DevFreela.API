using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Commands.ProjectCommand
{
    public class CancelProjectCommandHandler : IRequestHandler<CancelProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        public CancelProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(CancelProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (project == null) return Unit.Value;

            project.Cancel();
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
