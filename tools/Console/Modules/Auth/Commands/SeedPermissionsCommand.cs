using System.Reflection;

using VideoGame.Domain.Modules.Shared.Interfaces;
using VideoGame.Domain.Modules.Shared.Parents;

namespace Console.Modules.Auth.Commands;

public class SeedPermissionsCommand(IUnitOfWork unitOfWork) : IConsoleCommand
{
    public string Name { get; } = "seed:permissions";

    public async Task HandleAsync(string[] args, IServiceProvider provider)
    {
        System.Console.WriteLine("[+] Seeding permissions...");
        var applicationAssembly = Assembly.Load("VideoGame.Application");
        var permissionTypes = PermissionHelper.GetAllPermissionTypes(applicationAssembly);

        foreach (var permissionClass in permissionTypes)
        {
            var instance = (ParentPermissions?)Activator.CreateInstance(permissionClass);
            foreach (var pi in instance?.GetPermissions() ?? [])
            {
                if (pi is null)
                {
                    continue;
                }

                await unitOfWork.Permissions.FirstOrCreateByNameAsync(pi);
            }
        }

        System.Console.WriteLine("[+] Permissions seeded...");
    }
}
