using AutoMapper;
using DiscountService.Application.DTOs;
using DiscountService.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountService.Application.Queries.GetAllDiscounts
{
    public class GetAllDiscountsHandler : IRequestHandler<GetAllDiscountsQuery, IEnumerable<DiscountDto>>
    {
        private readonly IDiscountRepository _repository;
        private readonly IMapper _mapper;

        public GetAllDiscountsHandler(IDiscountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DiscountDto>> Handle(GetAllDiscountsQuery request, CancellationToken cancellationToken)
        {
            var discounts = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DiscountDto>>(discounts);
        }
    }
}
