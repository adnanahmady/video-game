using VideoGame.Domain.Modules.Shared.Interfaces;
using VideoGame.Domain.Modules.Shared.Parents;

namespace VideoGame.Application.Modules.Games.Support;

public class Permissions : ParentPermissions
{
    public const string CreateGame = "create-game";
    public const string UpdateGame = "update-game";
    public const string DeleteGame = "delete-game";
    public const string ViewGame = "view-game";
    public const string ListGames = "list-games";
}
