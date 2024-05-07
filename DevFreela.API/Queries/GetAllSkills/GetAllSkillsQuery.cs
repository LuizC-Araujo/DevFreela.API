using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.API.Queries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
    {
    }
}
