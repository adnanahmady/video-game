using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;
using VideoGame.Api.Core.Services.Auth;
using VideoGame.Api.RequestForms;

namespace VideoGame.Api.Application.Services.Auth;

public class RegisterService(VideoGameDbContext context) : IRegisterService
{
    public async Task<object?> RegisterAsync(UserForm form)
    {
        if (await context.Users.AnyAsync(u => u.Username == form.Username))
        {
            return null;
        }

        var user = new User();
        var hashedPassword = new PasswordHasher<User>()
            .HashPassword(user, form.Password);

        user.Username = form.Username;
        user.PasswordHash = hashedPassword;
        user.Role = await context.Roles.SingleAsync(r => r.Name == "User");

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return new {Id = user.Id, Username = user.Username};
    }
}
