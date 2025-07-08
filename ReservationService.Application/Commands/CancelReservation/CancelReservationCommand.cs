using MediatR;
using ReservationService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
