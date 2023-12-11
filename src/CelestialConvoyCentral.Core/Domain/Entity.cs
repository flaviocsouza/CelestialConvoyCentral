namespace CelestialConvoyCentral.Core;

public abstract class Entity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    public bool Active => DeletedAt is null;

    protected Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        DeletedAt = null;
    }

    protected void Delete()
    {
        DeletedAt = DateTime.Now;
    }
}
