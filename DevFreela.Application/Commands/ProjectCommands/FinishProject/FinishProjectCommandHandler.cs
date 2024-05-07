using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.ProjectCommands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        public FinishProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (project == null) return Unit.Value;

            project.Finish();
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
