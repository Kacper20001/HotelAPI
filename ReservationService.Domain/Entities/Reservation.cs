using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationService.Domain.Enums;

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
        public ReservationStatus Status { get; set; }

        [Required]
        public int RoomNumber { get; set; }
    }
}
