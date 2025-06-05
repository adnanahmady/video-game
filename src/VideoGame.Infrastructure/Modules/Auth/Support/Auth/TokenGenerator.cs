using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using VideoGame.Domain.Modules.Auth.Entities;
using VideoGame.Domain.Modules.Auth.Interfaces.Support.Auth;

namespace VideoGame.Infrastructure.Modules.Auth.Support.Auth;

public class TokenGenerator(
    VideoGameDbContext context,
    IConfiguration configuration) : ITokenGenerator
{
    public async Task<User?> ValidateRefreshTokenAsync(
        Guid userId, string refreshToken)
    {
        var user = await context.Users.FindAsync(userId);

        if (user is null || user.RefreshToken != refreshToken ||
            user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return null;
        }

        return user;
    }

    public string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            configuration["Auth:Token"]!
        ));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: configuration["Auth:Issuer"],
            audience: configuration["Auth:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    public async Task<string> GenerateRefreshTokenAsync(User user)
    {
        var refreshToken = CreateRefreshTokenString();
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await context.SaveChangesAsync();

        return refreshToken;
    }

    private string CreateRefreshTokenString()
    {
        var randomNumber = new byte[32];
        using var range = RandomNumberGenerator.Create();
        range.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }
}
