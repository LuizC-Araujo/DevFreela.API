using DevFreela.Core.Enums;
using MediatR;

namespace DevFreela.API.Commands.ProjectCommand
{
    public class FinishProjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
