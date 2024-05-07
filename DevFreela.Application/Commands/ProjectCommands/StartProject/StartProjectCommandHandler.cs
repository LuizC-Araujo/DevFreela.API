using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.ProjectCommands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        public StartProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (project == null) return Unit.Value;

            project.Start();
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
