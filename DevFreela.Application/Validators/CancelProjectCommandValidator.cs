using DevFreela.Application.Commands.ProjectCommands.CancelProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CancelProjectCommandValidator : AbstractValidator<CancelProjectCommand>
    {
        public CancelProjectCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Id deve ser fornecido!")
                .GreaterThan(0).WithMessage("O id deve ser maior que 0!");
        }
    }
}
