using DevFreela.Application.Commands.ProjectCommands.StartProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class StartProjectCommandValidator : AbstractValidator<StartProjectCommand>
    {
        public StartProjectCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Id deve ser fornecido!")
                .GreaterThan(0).WithMessage("O id deve ser maior que 0!");
        }
    }
}
