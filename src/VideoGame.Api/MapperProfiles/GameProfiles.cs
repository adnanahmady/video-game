using AutoMapper;

using VideoGame.Api.RequestForms.Games;
using VideoGame.Application.Dtos.Games;

namespace VideoGame.Api.MapperProfiles;

public class GameProfiles : Profile
{
    public GameProfiles()
    {
        CreateMap<CreateGameForm, GameDto>();
        CreateMap<UpdateGameForm, GameDto>();
    }
}
