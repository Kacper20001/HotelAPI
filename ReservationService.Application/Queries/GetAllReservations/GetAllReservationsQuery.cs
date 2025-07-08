using MediatR;
using ReservationService.Application.DTOs;

namespace ReservationService.Application.Queries.GetAllReservations
{
    public class GetAllReservationsQuery : IRequest<IEnumerable<ReservationDto>> 
    {
    }
}
