using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Dtos;
using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.RequestForms.Auth;
using VideoGame.Api.Infrastructure.Services.Auth;
using VideoGame.Api.Infrastructure.Support.Auth;

namespace VideoGame.Api.Application.Services.Auth;

public class LoginService(
    VideoGameDbContext context,
    ITokenGenerator tokenGenerator) : ILoginService
{
    public async Task<TokenResponseDto?> LoginAsync(UserForm form)
    {
        var user = await context.Users.Include(u => u.Role).SingleOrDefaultAsync(
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

        return new()
        {
            AccessToken = tokenGenerator.CreateToken(user),
            RefreshToken = await tokenGenerator.GenerateRefreshTokenAsync(user)
        };
    }
}
