using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscountService.Domain.Entities
{
    [Table("Discounts", Schema = "discount")]
    public class Discount : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Code { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Percentage { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime ValidFrom { get; set; }

        [Required]
        public DateTime ValidTo { get; set; }

        public string? Description { get; set; }
    }
}
