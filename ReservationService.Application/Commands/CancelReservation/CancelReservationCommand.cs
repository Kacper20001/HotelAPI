using MediatR;
using ReservationService.Application.DTOs;

namespace ReservationService.Application.Commands.CancelReservation
{
    public class CancelReservationCommand : IRequest<ReservationDto>
    {
        public Guid ReservationId { get; }

        public CancelReservationCommand(Guid reservationId)
        {
            ReservationId = reservationId;
        }
    }
}
