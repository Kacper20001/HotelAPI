using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Domain.Entities
{
    [Table("Addresses", Schema = "customer")]
    public class Address : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Street { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string City { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = null!;

        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; } = null!;
    }
}
