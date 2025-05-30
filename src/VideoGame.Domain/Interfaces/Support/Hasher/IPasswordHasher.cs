using VideoGame.Domain.Entities;

namespace VideoGame.Domain.Interfaces.Support.Hasher;

public interface IPasswordHasher
{
    bool Verify(User user, string passwordHash, string password);
    string? Hash(User user, string password);
}
