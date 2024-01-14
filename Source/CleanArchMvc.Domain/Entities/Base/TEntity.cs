namespace CleanArchMvc.Domain.Entities.Base;

public interface IEntity<TKey>
{
    TKey Id { get; protected set; }
}