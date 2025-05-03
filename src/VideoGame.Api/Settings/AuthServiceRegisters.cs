using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace VideoGame.Api.Settings;

public static class AuthServiceRegisters
{
    public static void AddServices(
        IConfiguration configuration,
        IServiceCollection services) =>
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
}
