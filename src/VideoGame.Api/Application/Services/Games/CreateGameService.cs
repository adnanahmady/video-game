using AutoMapper;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure;
using VideoGame.Api.Infrastructure.RequestForms.Games;
using VideoGame.Api.Infrastructure.Services.Games;

namespace VideoGame.Api.Application.Services.Games;

public class CreateGameService(IUnitOfWork unitOfWork, IMapper mapper) : ICreateGameService
{
    public async Task<Game> CreateAsync(CreateGameForm form)
    {
        var game = mapper.Map<CreateGameForm, Game>(form);

        await unitOfWork.Games.AddAsync(game);
        await unitOfWork.CommitAsync();

        return game;
    }
}
