using AutoMapper;
using MediatR;
using ReservationService.Application.DTOs;
using ReservationService.Application.Interfaces;
using ReservationService.Domain.Enums;

namespace ReservationService.Application.Commands.ConfirmReservation
{
    public class ConfirmReservationHandler : IRequestHandler<ConfirmReservationCommand, ReservationDto>
    {
        private readonly IReservationRepository _repository;
        private readonly IMapper _mapper;

        public ConfirmReservationHandler(IReservationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReservationDto> Handle(ConfirmReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _repository.GetByIdAsync(request.ReservationId)
                ?? throw new Exception("Reservation not found");

            reservation.Status = ReservationStatus.Confirmed;
            reservation.ModifiedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(reservation);

            return _mapper.Map<ReservationDto>(reservation);
        }
    }
}
