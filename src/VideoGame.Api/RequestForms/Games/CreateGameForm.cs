namespace VideoGame.Api.RequestForms.Games;

public class UpdateGameForm
{
    public string Title { get; set; } = string.Empty;
    public string Platform { get; set; } = string.Empty;
    public string? Developer { get; set; }
    public string? Publisher { get; set; }
}
