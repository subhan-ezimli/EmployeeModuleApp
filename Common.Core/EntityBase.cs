namespace Common.Core
{
    public abstract class EntityBase<T>(Guid id) : IAuditableModel where T : class, IAuditableModel
    {
        public Id<T> Id { get; } = Id<T>.FromGuid(id);
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; } = DateTime.UtcNow;

        protected EntityBase() : this(Guid.NewGuid()) { }
        public override bool Equals(object? obj)
        {
            if (obj is null || (obj.GetType() != this.GetType()))
                return false;
            else return Id.Equals((obj as EntityBase<T>).Id);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
