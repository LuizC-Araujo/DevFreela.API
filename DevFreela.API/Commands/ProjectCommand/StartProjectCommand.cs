using DevFreela.Core.Enums;
using MediatR;

namespace DevFreela.API.Commands.ProjectCommand
{
    public class StartProjectCommand : IRequest<int>
    {
        public int Id { get; set; }
        public EProjectStatusEnum Status { get; set; }
    }
}
