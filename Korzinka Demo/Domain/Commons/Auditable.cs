namespace Korzinka_Demo.Domain.Commons
{
    public class Auditable
    {
        public Guid Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
