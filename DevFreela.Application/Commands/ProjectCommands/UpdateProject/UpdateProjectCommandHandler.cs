using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.ProjectCommands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        public UpdateProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (project == null) return Unit.Value;

            project.Update(request.Title, request.Description, request.TotalCost);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
