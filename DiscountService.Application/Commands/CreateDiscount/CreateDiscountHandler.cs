using AutoMapper;
using DiscountService.Application.DTOs;
using DiscountService.Application.Interfaces;
using DiscountService.Domain.Entities;
using MediatR;


namespace DiscountService.Application.Commands.CreateDiscount
{
    public class CreateDiscountHandler : IRequestHandler<CreateDiscountCommand, DiscountDto>
    {
        private readonly IDiscountRepository _repository;
        private readonly IMapper _mapper;

        public CreateDiscountHandler(IDiscountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DiscountDto> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = _mapper.Map<Discount>(request);
            await _repository.AddAsync(discount);
            return _mapper.Map<DiscountDto>(discount);
        }
    }
}
