namespace Exam1.Domain.Entity
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
