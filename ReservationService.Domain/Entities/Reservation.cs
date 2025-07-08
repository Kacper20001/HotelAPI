using ReservationService.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationService.Domain.Entities
{
    [Table("Reservations", Schema = "reservation")]
    public class Reservation : BaseEntity
    {
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        
        [Required]
        public int NumberOfGuests { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }


        [Required]
        public ReservationStatus Status { get; set; }

        [Required]
        public int RoomNumber { get; set; }
    }
}
