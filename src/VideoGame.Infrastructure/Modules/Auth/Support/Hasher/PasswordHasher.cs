using Microsoft.AspNetCore.Identity;

using VideoGame.Domain.Modules.Auth.Entities;
using VideoGame.Domain.Modules.Auth.Interfaces.Support.Hasher;

namespace VideoGame.Infrastructure.Modules.Auth.Support.Hasher;

public class PasswordHasher : IPasswordHasher
{
    public bool Verify(User user, string passwordHash, string password)
    {
        var isVerified = new PasswordHasher<User>().VerifyHashedPassword(
            user,
            passwordHash,
            password
        );

        return isVerified != PasswordVerificationResult.Failed;
    }

    public string? Hash(User user, string password) =>
        new PasswordHasher<User>().HashPassword(user, password);
}
