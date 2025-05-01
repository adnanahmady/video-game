namespace VideoGame.Api.Core.Entities;

public class Video
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Platform { get; set; }
    public string? Developer { get; set; }
    public string? Publisher { get; set; }
}
