namespace VideoGame.Api.Infrastructure.Support;

public class CustomError(string fieldName, params string[] errors)
{
    public Dictionary<string, string[]> Errors { get; set; } = new() { { fieldName, errors } };
}
