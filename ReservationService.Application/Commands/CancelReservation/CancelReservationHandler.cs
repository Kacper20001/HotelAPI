using AutoMapper;
using MediatR;
using ReservationService.Application.DTOs;
using ReservationService.Application.Interfaces;
using ReservationService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Application.Commands.CancelReservation
{
    public class CancelReservationHandler : IRequestHandler<CancelReservationCommand, ReservationDto>
    {
        private readonly IReservationRepository _repository;
        private readonly IMapper _mapper;

        public CancelReservationHandler(IReservationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReservationDto> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _repository.GetByIdAsync(request.ReservationId)
                ?? throw new Exception("Reservation not found");

            reservation.Status = ReservationStatus.Cancelled;
            reservation.ModifiedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(reservation);

            return _mapper.Map<ReservationDto>(reservation);
        }
    }
}
