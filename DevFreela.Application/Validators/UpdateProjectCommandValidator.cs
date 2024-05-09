using DevFreela.Application.Commands.ProjectCommands.UpdateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("O id deve ser preenchido")
                .GreaterThan(0).WithMessage("O id deve ser maior que 0");

            RuleFor(p => p.Title)
                .Length(1, 30).WithMessage("O título deve ter entre {MinLength} e {MaxLength}");

            RuleFor(p => p.Description)
                .Length(1, 255).WithMessage("A descrição deve ter entre {MinLength} e {MaxLength}");
        }
    }
}
