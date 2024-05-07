using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.ProjectCommands.SuspendProject
{
    public class SuspendProjectCommandHandler : IRequestHandler<SuspendProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        public SuspendProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(SuspendProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (project == null) return Unit.Value;

            project.Suspend();
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
