using Console;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using VideoGame.Application;
using VideoGame.Domain.Modules.Shared.Interfaces;
using VideoGame.Infrastructure;

var builder = Host.CreateApplicationBuilder(args);
var path = Path.GetFullPath(Directory.GetParent("tools") + "/src/VideoGame.Api/");
var env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";

builder.Configuration.SetBasePath(path)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddCommandLine(args);
builder.Services.AddInfrastructure(
    builder.Configuration["ConnectionStrings:Default"]!);
builder.Services.AddApplication();

var host = builder.Build();
var services = host.Services;

var commandName = args.Length > 0 ? args[0] : null;
var commandArgs = args.Skip(1).ToArray();

if (string.IsNullOrWhiteSpace(commandName))
{
    System.Console.WriteLine("[X] No command provided.");
    return;
}

var commands = typeof(IConsoleCommand).Assembly.GetTypes()
    .Where(t =>
        t is { IsClass: true, IsAbstract: false }
        && typeof(IConsoleCommand).IsAssignableFrom(t))
    .Select(t => (IConsoleCommand)Activator.CreateInstance(
        t,
        services.GetRequiredService<IUnitOfWork>())!)
    .ToList();
var command = commands.FirstOrDefault(c => c.Name == commandName);

if (command is null)
{
    System.Console.WriteLine($"[X] Command '{commandName}' not found.");
    System.Console.WriteLine("[Q] Available commands:");
    foreach (var c in commands)
    {
        System.Console.WriteLine($" - {c.Name}");
    }

    return;
}

await command.HandleAsync(commandArgs, services);
