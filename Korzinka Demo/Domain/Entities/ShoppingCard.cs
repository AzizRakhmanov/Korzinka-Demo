using Korzinka_Demo.Domain.Commons;
using Korzinka_Demo.Domain.Enums;

namespace Korzinka_Demo.Domain.Entities
{
    public class ShoppingCard : Auditable
    {
        public User User { get; set; }

        public List<Product> Products { get; set; }

        public ShoppingCardCondition Condition { get; set; }
    }
}
