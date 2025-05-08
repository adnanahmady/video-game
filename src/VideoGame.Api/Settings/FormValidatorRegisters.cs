using FluentValidation;

using VideoGame.Api.Infrastructure.RequestForms.Auth;
using VideoGame.Api.Infrastructure.RequestForms.Games;
using VideoGame.Api.Infrastructure.Validators.Auth;
using VideoGame.Api.Infrastructure.Validators.Games;

namespace VideoGame.Api.Settings;

public static class FormValidatorRegisters
{
    public static void AddServices(IServiceCollection services)
    {
        AuthValidators(services);
        GameValidators(services);
    }

    private static void AuthValidators(IServiceCollection services)
    {
        services.AddScoped<IValidator<UserForm>, UserFormValidator>();
        services.AddScoped<IValidator<RefreshTokenForm>, RefreshTokenFormValidator>();
    }

    private static void GameValidators(IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateGameForm>, CreateGameFormValidator>();
        services.AddScoped<IValidator<UpdateGameForm>, UpdateGameFormValidator>();
    }
}
