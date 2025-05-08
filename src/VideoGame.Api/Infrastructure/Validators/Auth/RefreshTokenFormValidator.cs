using FluentValidation;

using VideoGame.Api.Core;
using VideoGame.Api.Infrastructure.RequestForms.Auth;

namespace VideoGame.Api.Infrastructure.Validators.Auth;

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
