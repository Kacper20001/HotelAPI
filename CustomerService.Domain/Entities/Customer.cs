using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerService.Domain.Entities
{
    [Table("Customers", Schema = "customer")]
    public class Customer : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MaxLength(200)]
        public string Email { get; set; } = null!;

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [Required]
        [MaxLength(20)]
        public string IDCardNumber { get; set; } = null!;

        [Required]
        public DateTime DateOfBirth { get; set; }

        public Address Address { get; set; } = null!;
    }
}
