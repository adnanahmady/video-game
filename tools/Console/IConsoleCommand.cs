namespace Console;

public interface IConsoleCommand
{
    string Name { get; }

    Task HandleAsync(string[] args, IServiceProvider provider);
}
