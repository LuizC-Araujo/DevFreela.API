using DevFreela.Core.Enums;
using MediatR;

namespace DevFreela.API.Commands.ProjectCommand
{
    public class StartProjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
