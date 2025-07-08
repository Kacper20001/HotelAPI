using MediatR;
using ReservationService.Application.DTOs;

namespace ReservationService.Application.Commands.ConfirmReservation
{
    public class ConfirmReservationCommand : IRequest<ReservationDto>
    {
        public Guid ReservationId { get; set; }

        public ConfirmReservationCommand(Guid reservationId)
        {
            ReservationId = reservationId;
        }
    }
}
