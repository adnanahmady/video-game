namespace VideoGame.Domain.Interfaces;

public interface IEntity<TId> where TId : notnull
{
    TId Id { get; set; }
}
