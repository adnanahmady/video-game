namespace VideoGame.Api.Infrastructure.Services;

public interface IDeleteGameService
{
    Task<bool> DeleteAsync(int id);
}
