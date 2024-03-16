using Korzinka_Demo.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace Korzinka_Demo.Domain.Entities
{
    public class User : Auditable
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public UserAddress Address { get; set; }
    }
}
