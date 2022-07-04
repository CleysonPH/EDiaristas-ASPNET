using EDiaristas.Admin.Servicos.Dtos;
using FluentValidation;

namespace EDiaristas.Admin.Servicos.Validators;

public class ServiceFormValidator : AbstractValidator<ServicoForm>
{
    public ServiceFormValidator()
    {
        RuleFor(s => s.Nome)
            .NotEmpty()
            .WithMessage("é obrigatório.")
            .MinimumLength(3)
            .WithMessage("deve ter mais de 3 caracteres.")
            .MaximumLength(100)
            .WithMessage("deve conter até 100 caracteres.");

        RuleFor(s => s.ValorMinimo)
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0.");

        RuleFor(s => s.QtdHoras)
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0.");

        RuleFor(s => s.PorcentagemComissao)
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0.")
            .LessThanOrEqualTo(100)
            .WithMessage("deve ser menor ou igual a 100.");

        RuleFor(s => s.HorasQuarto)
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0.")
            .LessThan(24)
            .WithMessage("deve ser menor que 24.");

        RuleFor(s => s.ValorQuarto)
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0.");

        RuleFor(s => s.HorasSala)
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0.")
            .LessThan(24)
            .WithMessage("deve ser menor que 24.");

        RuleFor(s => s.ValorSala)
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0.");

        RuleFor(s => s.HorasBanheiro)
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0.")
            .LessThan(24)
            .WithMessage("deve ser menor que 24.");

        RuleFor(s => s.ValorBanheiro)
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0.");

        RuleFor(s => s.HorasCozinha)
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0.")
            .LessThan(24)
            .WithMessage("deve ser menor que 24.");

        RuleFor(s => s.ValorCozinha)
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0.");

        RuleFor(s => s.HorasQuintal)
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0.")
            .LessThan(24)
            .WithMessage("deve ser menor que 24.");

        RuleFor(s => s.ValorQuintal)
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0.");

        RuleFor(s => s.HorasOutros)
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0.")
            .LessThan(24)
            .WithMessage("deve ser menor que 24.");

        RuleFor(s => s.ValorOutros)
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0.");

        RuleFor(s => s.Icone)
            .Must(icone => icone >= 1 && icone <= 3)
            .WithMessage("opção inválida.");

        RuleFor(s => s.Posicao)
            .GreaterThan(0)
            .WithMessage("deve ser maior que 0.");
    }
}