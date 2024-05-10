using DevFreela.Application.Commands.ProjectCommands.FinishProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class FinishProjectCommandValidator : AbstractValidator<FinishProjectCommand>
    {
        public FinishProjectCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Id deve ser fornecido!")
                .GreaterThan(0).WithMessage("O id deve ser maior que 0!");
        }
    }
}
