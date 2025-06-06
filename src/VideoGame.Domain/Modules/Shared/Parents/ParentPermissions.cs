using VideoGame.Domain.Modules.Shared.Interfaces;

namespace VideoGame.Domain.Modules.Shared.Parents;

public abstract class ParentPermissions : IPermissions
{
    public List<string?> GetPermissions() =>
        GetType().GetFields()
            .Where(field => field is { IsStatic: true, IsPublic: true } && field.FieldType == typeof(string))
            .Select(field => (string)field.GetValue(null))
            .ToList();
}
