using MediatR;
using ReservationService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Application.Queries.GetReservationById
{
    public class GetReservationByIdQuery : IRequest<ReservationDto>
    {
        public Guid Id { get; set; }

        public GetReservationByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
