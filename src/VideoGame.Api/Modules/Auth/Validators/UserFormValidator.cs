using FluentValidation;

using VideoGame.Api.Modules.Auth.RequestForms;

namespace VideoGame.Api.Modules.Auth.Validators;

public class UserFormValidator : AbstractValidator<UserForm>
{
    public UserFormValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required.")
            .Length(3, 60)
            .WithMessage("Username must be between 3 and 60 characters long.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required.")
            .Length(6, 100)
            .WithMessage("Password must be at least 6 characters long.");
    }
}
