using AutoMapper;
using DiscountService.Application.DTOs;
using DiscountService.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountService.Application.Queries.GetDiscountById
{
    public class GetDiscountByIdHandler : IRequestHandler<GetDiscountByIdQuery, DiscountDto>
    {
        private readonly IDiscountRepository _repository;
        private readonly IMapper _mapper;

        public GetDiscountByIdHandler(IDiscountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DiscountDto> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken)
        {
            var discount = await _repository.GetByIdAsync(request.Id)
                ?? throw new KeyNotFoundException("Discount not found");

            return _mapper.Map<DiscountDto>(discount);
        }
    }
}
