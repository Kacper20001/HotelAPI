using ReservationService.Domain.Enums;

namespace ReservationService.Application.DTOs
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RoomNumber { get; set; } = null!;
        public ReservationStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
