namespace VideoGame.Api.Modules.Shared.Responses;

public class GeneralResource<T>(T data)
{
    public T Data { get; set; } = data;
}
