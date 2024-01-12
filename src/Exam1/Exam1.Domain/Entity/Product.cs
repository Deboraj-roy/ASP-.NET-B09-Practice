namespace Exam1.Domain.Entity
{
    public class Product : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public uint Price { get; set; }
        public double Weight { get; set; }
    }
}
