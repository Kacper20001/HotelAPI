using AutoMapper;
using MediatR;
using ReservationService.Application.DTOs;
using ReservationService.Application.Interfaces;
using ReservationService.Domain.Entities;
using ReservationService.Domain.Enums;
using Shared.DTOs;

namespace ReservationService.Application.Commands.CreateReservation
{
    public class CreateReservationHandler : IRequestHandler<CreateReservationCommand, ReservationDto>
    {
        private readonly IReservationRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICustomerApiClient _customerApiClient;
        private readonly IDiscountApiClient _discountApiClient;

        public CreateReservationHandler(
            IReservationRepository repository,
            IMapper mapper,
            ICustomerApiClient customerApiClient,
            IDiscountApiClient discountApiClient)
        {
            _repository = repository;
            _mapper = mapper;
            _customerApiClient = customerApiClient;
            _discountApiClient = discountApiClient;
        }

        public async Task<ReservationDto> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerApiClient.GetByIdAsync(request.CustomerId);
            if (customer is null)
                throw new Exception($"Customer with ID {request.CustomerId} not found.");

            if (request.DiscountId.HasValue)
            {
                var discount = await _discountApiClient.GetByIdAsync(request.DiscountId.Value);

                if (discount is null)
                    throw new Exception("Discount not found.");

                if (!discount.IsActive)
                    throw new Exception("Discount is not active.");

                if (discount.ValidFrom > DateTime.UtcNow || discount.ValidTo < DateTime.UtcNow)
                    throw new Exception("Discount is not valid at this time.");
            }

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
                DiscountId = request.DiscountId,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(reservation);

            return _mapper.Map<ReservationDto>(reservation);
        }
    }
}
