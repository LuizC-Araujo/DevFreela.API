using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.API.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>>
    {
    }
}
