namespace VideoGame.Api.Core.Entities;

public class Role : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<User> Users { get; set; } = new List<User>();
}
