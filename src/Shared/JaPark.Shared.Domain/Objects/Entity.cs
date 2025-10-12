namespace JaPark.Shared.Domain.Objects;

public abstract class Entity
{
    public DateTime CreatedAt { get; protected set; } = DateTime.Now;
    public DateTime UpdatedAt { get; protected set; }
    public DateTime DeletedAt { get; protected set; }
}
