using MediatR;

namespace ReservationService.Application.Commands.DeleteReservation
{
    public class DeleteReservationCommand : IRequest<Unit>
    {
        public Guid ReservationId { get; }

        public DeleteReservationCommand(Guid reservationId)
        {
            ReservationId = reservationId;
        }
    }
}
