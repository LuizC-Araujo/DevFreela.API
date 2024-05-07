using MediatR;

namespace DevFreela.API.Commands.UserCommands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
