using MediatR;
using ReservationService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
