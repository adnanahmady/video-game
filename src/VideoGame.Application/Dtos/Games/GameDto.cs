namespace VideoGame.Application.Dtos.Games;

public class GameDto
{
    public string Title { get; set; } = string.Empty;
    public string Platform { get; set; } = string.Empty;
    public string? Developer { get; set; }
    public string? Publisher { get; set; }
}
