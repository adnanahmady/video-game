namespace VideoGame.Api.Core.Entities;

public class User : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    public Role? Role { get; set; }
    public int? RoleId { get; set; }

    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}
