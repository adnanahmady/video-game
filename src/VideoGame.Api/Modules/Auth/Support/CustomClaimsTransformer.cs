using System.Security.Claims;

using Microsoft.AspNetCore.Authentication;

using VideoGame.Domain.Modules.Auth.Support;

namespace VideoGame.Api.Modules.Auth.Support;

public class CustomClaimsTransformer(IUserService userService) : IClaimsTransformation
{
    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var identity = (ClaimsIdentity?)principal.Identity;
        if (identity is null || !identity.IsAuthenticated)
        {
            return principal;
        }

        var userId = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!Guid.TryParse(userId, out var parsedId))
        {
            return principal;
        }

        var user = await userService.FindByIdAsync(parsedId);
        if (user is null)
        {
            return principal;
        }
        var role = await userService.GetRoleAsync(user);
        if (string.IsNullOrEmpty(role))
        {
            return principal;
        }
        identity.AddClaim(new Claim(ClaimTypes.Role, role));

        return principal;
    }
}
