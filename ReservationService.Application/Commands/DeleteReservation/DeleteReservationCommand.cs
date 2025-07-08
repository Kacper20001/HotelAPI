using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
