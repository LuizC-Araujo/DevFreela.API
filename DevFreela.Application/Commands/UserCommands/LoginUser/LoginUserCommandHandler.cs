using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.UserCommands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository) 
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Utilizar o mesmo algoritmo para criar o hash da senha passada
            var passwordHas = _authService.ComputeSha256Hash(request.Password);

            // Buscar no bd em user que tenha o email e senha em formato hash
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHas);

            // Se não existir retorna erro no login
            if (user == null) return null;

            // se existir, gera o token usando os dados do cliente
            var token = _authService.GenerateJwtToken(user.Email, user.Role);
            return new LoginUserViewModel(user.Email, token);
        }
    }
}
