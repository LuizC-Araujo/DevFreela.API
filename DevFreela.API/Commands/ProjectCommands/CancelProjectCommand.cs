using DevFreela.Core.Enums;
using MediatR;

namespace DevFreela.API.Commands.ProjectCommand
{
    public class CancelProjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
