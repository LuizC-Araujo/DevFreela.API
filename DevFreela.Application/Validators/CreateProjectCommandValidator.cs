using DevFreela.Application.Commands.ProjectCommands.CreateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("O título do projeto deve ser preenchido")
                .Length(3, 30).WithMessage("O título deve ter entre {MinLength} e {MaxLength}");

            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("A descrição deve ser preenchida")
                .Length(20, 255).WithMessage("A descrição deve ter entre {MinLength} e {MaxLength}");

            RuleFor(p => p.ClientId )
                .NotEmpty()
                .NotNull().WithMessage("O id do clienter deve ser preenchido")
                .GreaterThan(0).WithMessage("O id do cliente deve ser maior que 0");

            RuleFor(p => p.TotalCost)
                .NotEmpty()
                .NotNull().WithMessage("O custo deve ser preenchido")
                .GreaterThan(0);
        }
    }
}
