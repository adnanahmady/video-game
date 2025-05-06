using System.ComponentModel.DataAnnotations.Schema;

namespace VideoGame.Api.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public Role? Role { get; set; }
    public int? RoleId { get; set; }
}
