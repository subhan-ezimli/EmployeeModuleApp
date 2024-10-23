namespace Common.Core
{
    //factory method, template method pattern
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object?> GetEqualityComponents();
        public override bool Equals(object? obj)
        {
            if (obj is null || (obj.GetType() != this.GetType()))
                return false;
            else return GetEqualityComponents().SequenceEqual((obj as ValueObject).GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents().Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}
