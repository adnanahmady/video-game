using AutoMapper;

using VideoGame.Api.Modules.Games.RequestForms;
using VideoGame.Application.Modules.Games.Dtos;

namespace VideoGame.Api.Modules.Games.MapperProfiles;

public class GameProfiles : Profile
{
    public GameProfiles()
    {
        CreateMap<CreateGameForm, GameDto>();
        CreateMap<UpdateGameForm, GameDto>();
    }
}
