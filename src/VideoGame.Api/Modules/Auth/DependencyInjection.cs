using System.Text;

using FluentValidation;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using VideoGame.Api.Modules.Auth.RequestForms;
using VideoGame.Api.Modules.Auth.Validators;
using VideoGame.Application.Modules.Auth.Interfaces;
using VideoGame.Application.Modules.Auth.Services;

namespace VideoGame.Api.Modules.Auth;

public static class DependencyInjection
{
    public static IServiceCollection AddApiAuthModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AddTokenHandler(services, configuration);

        AddUnitOfWork(services);
        AddValidators(services);

        return services;
    }

    private static void AddTokenHandler(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Auth:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["Auth:Audience"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Auth:Token"]!)
                    ),
                    ValidateIssuerSigningKey = true,
                };
            });

    private static void AddUnitOfWork(this IServiceCollection services) =>
        services.AddScoped<IAuthWork, AuthWork>();

    private static void AddValidators(IServiceCollection services)
    {
        services.AddScoped<IValidator<UserForm>, UserFormValidator>();
        services.AddScoped<IValidator<RefreshTokenForm>, RefreshTokenFormValidator>();
    }
}
