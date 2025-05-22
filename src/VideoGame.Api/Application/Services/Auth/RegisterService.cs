using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Dtos.Auth;
using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure;
using VideoGame.Api.Infrastructure.RequestForms.Auth;
using VideoGame.Api.Infrastructure.Services.Auth;

namespace VideoGame.Api.Application.Services.Auth;

public class RegisterService(IUnitOfWork unitOfWork) : IRegisterService
{
    public async Task<RegisteredUserDto?> RegisterAsync(UserForm form)
    {
        if (await unitOfWork.Users.AnyAsync(u => u.Username == form.Username))
        {
            return null;
        }

        var user = new User();
        var hashedPassword = new PasswordHasher<User>()
            .HashPassword(user, form.Password);

        user.Username = form.Username;
        user.PasswordHash = hashedPassword;
        user.Role = await unitOfWork.Roles.FindAsync(r => r.Name == "User");

        await unitOfWork.Users.AddAsync(user);
        await unitOfWork.CommitAsync();

        return new()
        {
            Id = user.Id,
            Username = user.Username
        };
    }
}
