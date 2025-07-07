using CustomerService.Application.Commands.CreateCustomer;
using CustomerService.Application.Commands.DeleteCustomer;
using CustomerService.Application.Commands.UpdateCustomer;
using CustomerService.Application.DTOs;
using CustomerService.Application.Queries.GetAllCustomers;
using CustomerService.Application.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerCommand command)
        {
            if (id != command.Id)
                return BadRequest("Mismatched customer ID.");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteCustomerCommand(id));
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomerDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetCustomerByIdQuery(id));
            return Ok(result);
        }
    }
}
