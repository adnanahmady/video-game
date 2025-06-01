using VideoGame.Domain.Modules.Auth.Entities;

namespace VideoGame.Domain.Modules.Auth.Interfaces.Support.Auth;

public interface ITokenGenerator
{
    Task<User?> ValidateRefreshTokenAsync(Guid userId, string refreshToken);
    string CreateToken(User user);
    Task<string> GenerateRefreshTokenAsync(User user);
}
