using DiscountService.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountService.Application.Commands.DeleteDiscount
{
    public class DeleteDiscountHandler : IRequestHandler<DeleteDiscountCommand, Unit>
    {
        private readonly IDiscountRepository _repository;

        public DeleteDiscountHandler(IDiscountRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = await _repository.GetByIdAsync(request.Id)
                ?? throw new KeyNotFoundException("Discount not found");

            await _repository.DeleteAsync(discount);
            return Unit.Value;
        }
    }
}
