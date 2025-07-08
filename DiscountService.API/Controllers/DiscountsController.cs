using DiscountService.Application.Commands.CreateDiscount;
using DiscountService.Application.Commands.DeleteDiscount;
using DiscountService.Application.Commands.UpdateDiscount;
using DiscountService.Application.DTOs;
using DiscountService.Application.Queries.GetAllDiscounts;
using DiscountService.Application.Queries.GetDiscountById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DiscountService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscountDto>>> GetAll()
        {
            var discounts = await _mediator.Send(new GetAllDiscountsQuery());
            return Ok(discounts);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DiscountDto>> GetById(Guid id)
        {
            var discount = await _mediator.Send(new GetDiscountByIdQuery(id));
            return Ok(discount);
        }

        [HttpPost]
        public async Task<ActionResult<DiscountDto>> Create([FromBody] CreateDiscountCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<DiscountDto>> Update(Guid id, [FromBody] UpdateDiscountCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID in URL and body do not match.");

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteDiscountCommand(id));
            return NoContent();
        }
    }
}
