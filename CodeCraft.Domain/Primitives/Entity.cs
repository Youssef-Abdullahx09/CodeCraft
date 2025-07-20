namespace CodeCraft.Domain.Primitives;


public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; protected set; }

    public Guid CreatedById { get; private set; }
    public DateTime CreationDate { get; private set; }
    public Guid? LastModifiedById { get; private set; }
    public DateTime? LastModificationDate { get; private set; }
    public Guid? DeletedById { get; private set; }
    public DateTime? DeletionDate { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsActive { get; private set; } = true;

    public bool Equals(Entity? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return GetType() == other.GetType() && Id.Equals(other.Id);
    }

    protected void MarkAsCreated(
        Guid userId)
    {
        CreatedById = userId;
        CreationDate = DateTime.UtcNow;
    }

    protected void MarkAsModified(
        Guid userId)
    {
        LastModifiedById = userId;
        LastModificationDate = DateTime.UtcNow;
    }

    protected void MarkAsDeleted(
        Guid userId)
    {
        IsDeleted = true;
        DeletedById = userId;
        DeletionDate = DateTime.UtcNow;
    }

    protected void InitiateStatus(
        bool isActive)
    {
        IsActive = isActive;
    }

    protected void SetStatus(
        bool isActive,
        Guid userId)
    {
        IsActive = isActive;
        LastModifiedById = userId;
        LastModificationDate = DateTime.UtcNow;
    }

    public static bool operator ==(Entity? left, Entity? right)
    {
        if (ReferenceEquals(left, right))
            return true;

        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }

    public static bool operator !=(Entity? left, Entity? right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity entity)
            return false;

        if (ReferenceEquals(this, entity))
            return true;

        return GetType() == entity.GetType() && Id.Equals(entity.Id);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}