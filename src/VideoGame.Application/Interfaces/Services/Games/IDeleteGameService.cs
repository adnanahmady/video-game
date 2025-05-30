namespace VideoGame.Application.Interfaces.Services.Games;

public interface IDeleteGameService
{
    Task<bool> DeleteAsync(int id);
}
