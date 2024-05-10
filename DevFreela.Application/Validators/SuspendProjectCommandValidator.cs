using DevFreela.Application.Commands.ProjectCommands.SuspendProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class SuspendProjectCommandValidator : AbstractValidator<SuspendProjectCommand>
    {
        public SuspendProjectCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Id deve ser fornecido!")
                .GreaterThan(0).WithMessage("O id deve ser maior que 0!");
        }
    }
}
