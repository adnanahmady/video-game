using VideoGame.Domain.Modules.Auth.Entities;

namespace VideoGame.Domain.Modules.Auth.Interfaces.Support.Hasher;

public interface IPasswordHasher
{
    bool Verify(User user, string passwordHash, string password);
    string? Hash(User user, string password);
}
