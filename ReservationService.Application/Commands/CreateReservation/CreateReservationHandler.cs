using AutoMapper;
using MediatR;
using ReservationService.Application.DTOs;
using ReservationService.Application.Interfaces;
using ReservationService.Domain.Entities;
using ReservationService.Domain.Enums;

namespace ReservationService.Application.Commands.CreateReservation
{
    public class CreateReservationHandler : IRequestHandler<CreateReservationCommand, ReservationDto>
    {
        private readonly IReservationRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICustomerApiClient _customerApiClient;

        public CreateReservationHandler(IReservationRepository repository, IMapper mapper, ICustomerApiClient customerApiClient)
        {
            _repository = repository;
            _mapper = mapper;
            _customerApiClient = customerApiClient;
        }

        public async Task<ReservationDto> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                CustomerId = request.CustomerId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                NumberOfGuests = request.NumberOfGuests,
                Price = request.Price,
                RoomNumber = request.RoomNumber,
                Status = ReservationStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(reservation);

            return _mapper.Map<ReservationDto>(reservation);
        }
    }
}
