namespace VideoGame.Api.Infrastructure.Services.Games;

public interface IDeleteGameService
{
    Task<bool> DeleteAsync(int id);
}
