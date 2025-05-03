using FluentValidation;

using VideoGame.Api.Infrastructur.Auth;
using VideoGame.Api.RequestForms;

namespace VideoGame.Api.Settings;

public static class FormValidatorRegisters
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IValidator<UserForm>, UserFormValidator>();
    }
}
