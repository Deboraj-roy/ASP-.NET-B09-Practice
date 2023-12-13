namespace FirstDemo.Domain.Entities
{
    public class Topic : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}