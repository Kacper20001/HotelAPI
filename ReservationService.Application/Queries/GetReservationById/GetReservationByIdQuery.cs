using MediatR;
using ReservationService.Application.DTOs;

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
