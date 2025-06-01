namespace VideoGame.Api.Modules.Shared.Support;

public class CustomError(string fieldName, params string[] errors)
{
    public Dictionary<string, string[]> Errors { get; set; } = new() { { fieldName, errors } };
}
