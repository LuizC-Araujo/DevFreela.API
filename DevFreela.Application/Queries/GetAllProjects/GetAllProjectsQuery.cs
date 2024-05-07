using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>>
    {
    }
}
