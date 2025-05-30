using AutoMapper;

using VideoGame.Api.RequestForms.Auth;
using VideoGame.Application.Dtos.Auth;

namespace VideoGame.Api.MapperProfiles;

public class AuthProfiles : Profile
{
    public AuthProfiles()
    {
        CreateMap<RefreshTokenForm, RefreshTokenDto>();
        CreateMap<UserForm, UserDto>();
    }
}
