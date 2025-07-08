using AutoMapper;
using DiscountService.Application.DTOs;
using DiscountService.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountService.Application.Commands.UpdateDiscount
{
    public class UpdateDiscountHandler : IRequestHandler<UpdateDiscountCommand, DiscountDto>
    {
        private readonly IDiscountRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDiscountHandler(IDiscountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DiscountDto> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = await _repository.GetByIdAsync(request.Id)
                ?? throw new KeyNotFoundException("Discount not found");

            _mapper.Map(request, discount);
            discount.ModifiedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(discount);
            return _mapper.Map<DiscountDto>(discount);
        }
    }
}
