namespace VideoGame.Application.Modules.Games.Interfaces;

public interface IDeleteGameService
{
    Task<bool> DeleteAsync(int id);
}
