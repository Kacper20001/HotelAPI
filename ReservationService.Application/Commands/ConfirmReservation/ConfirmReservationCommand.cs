using MediatR;
using ReservationService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
