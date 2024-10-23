namespace Common.Core
{
    public interface IAuditableModel
    {
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
    }
}
