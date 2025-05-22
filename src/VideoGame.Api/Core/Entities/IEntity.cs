namespace VideoGame.Api.Core.Entities;

public interface IEntity<TId> where TId : notnull
{
    TId Id { get; set; }
}
