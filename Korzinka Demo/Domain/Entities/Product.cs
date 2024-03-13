using Korzinka_Demo.Domain.Commons;

namespace Korzinka_Demo.Domain.Entities
{
    public class Product : Auditable
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset ExpireDate { get; set; }

        public ProductAddress Address { get; set; }

        public string Description { get; set; }

    }
}
