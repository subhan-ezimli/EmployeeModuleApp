namespace Common.Core
{
    public class Id<TModel>(Guid value) where TModel : class, IAuditableModel
    {
        public Guid Value { get; } = value;

        public Id() : this(Guid.NewGuid()) { }

        public static implicit operator Guid(Id<TModel> model)
        {
            return model.Value;
        }

        public static implicit operator Id<TModel>(Guid value)
        {
            return new Id<TModel>(value);
        }
        public static Id<TModel> FromGuid(Guid value)
        {
            return new Id<TModel>(value);
        }
    }
}
