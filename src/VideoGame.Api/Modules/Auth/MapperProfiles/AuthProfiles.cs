using AutoMapper;

using VideoGame.Api.Modules.Auth.RequestForms;
using VideoGame.Application.Modules.Auth.Dtos;

namespace VideoGame.Api.Modules.Auth.MapperProfiles;

public class AuthProfiles : Profile
{
    public AuthProfiles()
    {
        CreateMap<RefreshTokenForm, RefreshTokenDto>();
        CreateMap<UserForm, UserDto>();
    }
}
