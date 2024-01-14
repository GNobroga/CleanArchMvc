namespace CleanArchMvc.Domain.Entities.Base;

public class BaseEntity<TKey> : IEntity<TKey>
{
    public TKey Id { get; set; } = default!;
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}