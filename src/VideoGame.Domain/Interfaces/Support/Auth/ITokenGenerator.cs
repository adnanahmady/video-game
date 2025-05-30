using VideoGame.Domain.Entities;

namespace VideoGame.Domain.Interfaces.Support.Auth;

public interface ITokenGenerator
{
    Task<User?> ValidateRefreshTokenAsync(Guid userId, string refreshToken);
    string CreateToken(User user);
    Task<string> GenerateRefreshTokenAsync(User user);
}
