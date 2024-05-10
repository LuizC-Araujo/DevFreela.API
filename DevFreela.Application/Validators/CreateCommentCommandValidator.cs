using DevFreela.Application.Commands.ProjectCommands.CreateComment;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(c => c.Content)
                .NotEmpty()
                .NotNull().WithMessage("O conteúdo deve ser preenchido!")
                .MaximumLength(255).WithMessage("O tamanho máximo do conteúdo é de 255 carateres!");

            RuleFor(c => c.IdUser)
                .NotEmpty()
                .NotNull().WithMessage("O id do usuário deve ser preenchido")
                .GreaterThan(0).WithMessage("O id do usuário deve ser mair que 0");

            RuleFor(c => c.IdProject)
                .NotEmpty()
                .NotNull().WithMessage("O id do projeto deve ser preenchido")
                .GreaterThan(0).WithMessage("O id do projeto deve ser mair que 0");
        }
    }
}
