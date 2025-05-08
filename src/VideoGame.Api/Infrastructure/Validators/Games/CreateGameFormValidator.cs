using FluentValidation;

using VideoGame.Api.Infrastructure.RequestForms.Games;

namespace VideoGame.Api.Infrastructure.Validators.Games;

public class CreateGameFormValidator : AbstractValidator<CreateGameForm>
{
    public CreateGameFormValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .Length(3, 100)
            .WithMessage("Title must be between 3 to 100 characters long.");

        RuleFor(x => x.Platform)
            .NotEmpty()
            .WithMessage("Platform is required.")
            .Length(3, 50)
            .WithMessage("Platform must be between 3 to 50 characters long.");

        RuleFor(x => x.Developer)
            .Length(3, 50)
            .WithMessage("Developer must be between 3 to 50 characters long.");

        RuleFor(x => x.Publisher)
            .Length(3, 50)
            .WithMessage("Publisher must be between 3 to 50 characters long.");
    }
}
