namespace ApplicationCore.Entities
{
    // Can use BaseEntity<T> and public T Id to support different keys.
    public abstract class BaseEntity
    {
        public virtual long Id { get; protected set; }
    }
}
