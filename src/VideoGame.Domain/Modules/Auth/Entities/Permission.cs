using VideoGame.Domain.Modules.Shared.Interfaces;

namespace VideoGame.Domain.Modules.Auth.Entities;

public class Permission : IEntity<int>
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;

    public ICollection<Role> Roles { get; set; } = new List<Role>();
}
