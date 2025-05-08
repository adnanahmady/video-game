using FluentValidation;

using VideoGame.Api.Infrastructur.Auth;
using VideoGame.Api.RequestForms;
using VideoGame.Api.Infrastructure.RequestForms.Games;
using VideoGame.Api.Infrastructure.Validators.Games;

namespace VideoGame.Api.Settings;

public static class FormValidatorRegisters
{
    public static void AddServices(IServiceCollection services)
    {
        AuthValidators(services);
        GameValidators(services);
    }

    private static void AuthValidators(IServiceCollection services) =>
        services.AddScoped<IValidator<UserForm>, UserFormValidator>();

    private static void GameValidators(IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateGameForm>, CreateGameFormValidator>();
        services.AddScoped<IValidator<UpdateGameForm>, UpdateGameFormValidator>();
    }
}
