using System.Reflection;

using VideoGame.Domain.Modules.Shared.Interfaces;

namespace VideoGame.Domain.Modules.Shared.Parents;

public static class PermissionHelper
{
    public static IEnumerable<Type> GetAllPermissionTypes(
        Assembly assembly)
    {
        var permissionType = typeof(ParentPermissions);

        return assembly.GetTypes()
            .Where(t =>
                !t.IsInterface
                && !t.IsAbstract
                && permissionType.IsAssignableFrom(t));
    }
}
