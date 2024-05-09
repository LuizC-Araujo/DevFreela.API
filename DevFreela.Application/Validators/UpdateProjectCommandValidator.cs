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
                .MaximumLength(30).WithMessage("O título deve ter no máximo {MaxLength} caracteres");

            RuleFor(p => p.Description)
                .MaximumLength(255).WithMessage("A descrição deve ter no máximo {MaxLength} caracteres");

            RuleFor(p => p.TotalCost)
                .GreaterThan(0);
        }
    }
}
