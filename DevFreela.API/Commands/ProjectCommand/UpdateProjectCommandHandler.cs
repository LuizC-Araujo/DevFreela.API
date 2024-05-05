using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Commands.ProjectCommand
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;
        public UpdateProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (project == null) return 0;

            project.Update(request.Title, request.Description, request.TotalCost);

            await _dbContext.SaveChangesAsync();

            return project.Id;
        }
    }
}
