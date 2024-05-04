using MediatR;

namespace DevFreela.API.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<int>
    {
        public string Content { get; set; }
        public int IdProject { get; set; }
        public int IdUser { get; set; }
    }
}
