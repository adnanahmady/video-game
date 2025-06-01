namespace VideoGame.Domain.Modules.Shared.Interfaces;

public interface IEntity<TId> where TId : notnull
{
    TId Id { get; set; }
}
