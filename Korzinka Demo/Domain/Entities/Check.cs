using Korzinka_Demo.Domain.Commons;
using Korzinka_Demo.Domain.Enums;

namespace Korzinka_Demo.Domain.Entities
{
    public class Check : Auditable
    {
        public ShoppingCard ShoppingCard { get; set; }

        public CheckCondition Condition { get; set; }

    }
}
