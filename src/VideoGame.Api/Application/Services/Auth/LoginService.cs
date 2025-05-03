using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;
using VideoGame.Api.Core.Services.Auth;
using VideoGame.Api.RequestForms;

namespace VideoGame.Api.Application.Services.Auth;

public class LoginService(
    VideoGameDbContext context,
    IConfiguration configuration) : ILoginService
{
    public async Task<string?> LoginAsync(UserForm form)
    {
        var user = await context.Users.SingleOrDefaultAsync(
            u => u.Username == form.Username);

        if (user is null)
        {
            return null;
        }

        var isVerified = new PasswordHasher<User>().VerifyHashedPassword(
            user,
            user.PasswordHash,
            form.Password
        );

        if (isVerified == PasswordVerificationResult.Failed)
        {
            return null;
        }

        var token = CreateToken(user);

        return token;
    }

    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            configuration.GetValue<string>("Auth:Token")!
        ));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: configuration.GetValue<string>("Auth:Issuer"),
            audience: configuration.GetValue<string>("Auth:Audience"),
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}
