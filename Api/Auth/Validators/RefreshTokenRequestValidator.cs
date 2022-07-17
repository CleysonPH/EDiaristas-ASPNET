using EDiaristas.Api.Auth.Dtos;
using FluentValidation;

namespace EDiaristas.Api.Auth.Validators;

public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidator()
    {
        RuleFor(x => x.Refresh)
            .NotEmpty()
            .WithMessage("é obrigatório")
            .OverridePropertyName("refresh");
    }
}