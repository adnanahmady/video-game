using VideoGame.Domain.Modules.Shared.Interfaces;

namespace VideoGame.Domain.Modules.Games.Entities;

public class Game : IEntity<int>
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Platform { get; set; }
    public string? Developer { get; set; }
    public string? Publisher { get; set; }
}
