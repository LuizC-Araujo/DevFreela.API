using DevFreela.Core.Enums;
using MediatR;

namespace DevFreela.API.Commands.ProjectCommand
{
    public class CancelProjectCommand : IRequest<int>
    {
        public int Id { get; set; }
        public ProjectStatusEnum Status { get; set; }
    }
}
