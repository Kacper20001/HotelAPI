using AutoMapper;
using MediatR;
using ReservationService.Application.DTOs;
using ReservationService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Application.Queries.GetAllReservations
{
    public class GetAllReservationsHandler : IRequestHandler<GetAllReservationsQuery, IEnumerable<ReservationDto>>
    {
        private readonly IReservationRepository _repository;
        private readonly IMapper _mapper;

        public GetAllReservationsHandler(IReservationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReservationDto>>(reservations);
        }
    }
}
