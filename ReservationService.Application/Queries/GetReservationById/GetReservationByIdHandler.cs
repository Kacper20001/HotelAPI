using AutoMapper;
using MediatR;
using ReservationService.Application.DTOs;
using ReservationService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Application.Queries.GetReservationById
{
    public class GetReservationByIdHandler : IRequestHandler<GetReservationByIdQuery, ReservationDto>
    {
        private readonly IReservationRepository _repository;
        private readonly IMapper _mapper;

        public GetReservationByIdHandler(IReservationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReservationDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<ReservationDto>(reservation);
        }
    }
}
