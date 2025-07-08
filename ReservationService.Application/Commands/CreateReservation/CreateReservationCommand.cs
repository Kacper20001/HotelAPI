using MediatR;
using ReservationService.Application.DTOs;

namespace ReservationService.Application.Commands.CreateReservation
{
    public class CreateReservationCommand : IRequest<ReservationDto>
    {
        public Guid CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomNumber { get; set; }
    }
}
