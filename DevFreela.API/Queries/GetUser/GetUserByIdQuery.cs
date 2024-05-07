using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.API.Queries.GetUser
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public int Id { get; private set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
