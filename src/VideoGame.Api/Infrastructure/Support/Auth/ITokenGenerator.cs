using VideoGame.Api.Core.Entities;

namespace VideoGame.Api.Infrastructure.Support.Auth;

public interface ITokenGenerator
{
    Task<User?> ValidateRefreshTokenAsync(Guid userId, string refreshToken);
    string CreateToken(User user);
    Task<string> GenerateRefreshTokenAsync(User user);
}
