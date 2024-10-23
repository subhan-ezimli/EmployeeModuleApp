namespace Common.Core
{
    //Domain Events
    public abstract class Aggregate<T> : EntityBase<T> where T : class, IAuditableModel
    {
        private readonly List<IDomainEvent> _domainEvents = [];
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
        public IReadOnlyCollection<IDomainEvent> GetDomainEvents()
        {
           return _domainEvents.AsReadOnly();
        }
        
        protected void RaiseDomainEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }
        protected Aggregate(Guid id) : base(id) { }
        protected Aggregate() : base() { }
    }
}
