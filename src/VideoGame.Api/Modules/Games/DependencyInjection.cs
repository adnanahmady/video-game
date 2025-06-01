using FluentValidation;

using VideoGame.Api.Modules.Games.RequestForms;
using VideoGame.Api.Modules.Games.Validators;
using VideoGame.Application.Modules.Games.Interfaces;
using VideoGame.Application.Modules.Games.Services;

namespace VideoGame.Api.Modules.Games;

public static class DependencyInjection
{
    public static IServiceCollection AddApiGamesModule(this IServiceCollection services)
    {
        AddUnitOfWork(services);
        AddValidators(services);

        return services;
    }

    private static void AddUnitOfWork(this IServiceCollection services) =>
        services.AddScoped<IGameWork, GameWork>();

    private static void AddValidators(IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateGameForm>, CreateGameFormValidator>();
        services.AddScoped<IValidator<UpdateGameForm>, UpdateGameFormValidator>();
    }
}
