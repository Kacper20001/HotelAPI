using MediatR;
using ReservationService.Application.Interfaces;

namespace ReservationService.Application.Commands.DeleteReservation
{
    public class DeleteReservationHandler : IRequestHandler<DeleteReservationCommand, Unit>
    {
        private readonly IReservationRepository _repository;

        public DeleteReservationHandler(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _repository.GetByIdAsync(request.ReservationId)
                ?? throw new Exception("Reservation not found");

            await _repository.DeleteAsync(reservation);
            return Unit.Value;
        }
    }
}
