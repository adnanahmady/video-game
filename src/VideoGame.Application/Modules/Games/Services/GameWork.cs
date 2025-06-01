using VideoGame.Application.Modules.Games.Interfaces;
using VideoGame.Domain.Modules.Shared.Interfaces;

namespace VideoGame.Application.Modules.Games.Services;

public class GameWork(IUnitOfWork unitOfWork) : IGameWork
{
    public IShowGameService ShowService { get; } = new ShowGameService(unitOfWork);
    public IListGamesService ListService { get; } = new ListGamesService(unitOfWork);
    public ICreateGameService CreateService { get; } = new CreateGameService(unitOfWork);
    public IUpdateGameService UpdateService { get; } = new UpdateGameService(unitOfWork);
    public IDeleteGameService DeleteService { get; } = new DeleteGameService(unitOfWork);
}
