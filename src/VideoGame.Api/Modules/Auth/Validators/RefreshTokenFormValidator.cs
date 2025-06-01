using FluentValidation;

using VideoGame.Api.Modules.Auth.RequestForms;
using VideoGame.Infrastructure;

namespace VideoGame.Api.Modules.Auth.Validators;

public class RefreshTokenFormValidator : AbstractValidator<RefreshTokenForm>
{
    public RefreshTokenFormValidator(VideoGameDbContext context)
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required.")
            .Must((_, id) => context.Users.FirstOrDefault(u => u.Id == id) != null)
            .WithMessage("Refresh token is invalid or expired.");

        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .WithMessage("RefreshToken is required.")
            .Must((form, token) => context.Users.FirstOrDefault(
                u => u.RefreshToken == token && u.Id == form.UserId) != null)
            .WithMessage("Refresh token is invalid or expired.");
    }
}
