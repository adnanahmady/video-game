using FluentValidation;

using VideoGame.Api.Modules.Games.RequestForms;

namespace VideoGame.Api.Modules.Games.Validators;

public class UpdateGameFormValidator : AbstractValidator<UpdateGameForm>
{
    public UpdateGameFormValidator()
    {
        RuleFor(x => x.Title)
            .Length(3, 100)
            .WithMessage("Title must be between 3 to 100 characters long.");

        RuleFor(x => x.Platform)
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
