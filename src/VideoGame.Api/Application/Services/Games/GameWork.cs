using AutoMapper;

using VideoGame.Api.Core;
using VideoGame.Api.Infrastructure;
using VideoGame.Api.Infrastructure.Services.Games;

namespace VideoGame.Api.Application.Services.Games;

public class GameWork(IUnitOfWork unitOfWork, IMapper mapper) : IGameWork
{
    public IShowGameService ShowService { get; } = new ShowGameService(unitOfWork);
    public IListGamesService ListService { get; } = new ListGamesService(unitOfWork);
    public ICreateGameService CreateService { get; } = new CreateGameService(unitOfWork, mapper);
    public IUpdateGameService UpdateService { get; } = new UpdateGameService(unitOfWork, mapper);
    public IDeleteGameService DeleteService { get; } = new DeleteGameService(unitOfWork);
}
