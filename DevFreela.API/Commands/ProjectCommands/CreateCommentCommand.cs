using MediatR;

namespace DevFreela.API.Commands.ProjectCommand
{
    public class CreateCommentCommand : IRequest<Unit>
    {
        public string Content { get; set; }
        public int IdProject { get; set; }
        public int IdUser { get; set; }
    }
}
