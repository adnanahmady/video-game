namespace VideoGame.Api.Responses.Shared;

public class GeneralResource<T>(T data)
{
    public T Data { get; set; } = data;
}
