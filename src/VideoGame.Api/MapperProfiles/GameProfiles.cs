using AutoMapper;

using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.RequestForms.Games;

namespace VideoGame.Api.MapperProfiles;

public class GameProfiles : Profile
{
    public GameProfiles()
    {
        CreateMap<CreateGameForm, Game>()
            .ForMember(g => g.Id, opt => opt.Ignore());
        CreateMap<UpdateGameForm, Game>()
            .ForMember(g => g.Id, opt => opt.Ignore());
    }
}
