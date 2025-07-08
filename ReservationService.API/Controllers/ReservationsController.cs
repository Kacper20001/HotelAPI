using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReservationService.Application.Commands.CancelReservation;
using ReservationService.Application.Commands.ConfirmReservation;
using ReservationService.Application.Commands.CreateReservation;
using ReservationService.Application.Commands.DeleteReservation;
using ReservationService.Application.Queries.GetAllReservations;
using ReservationService.Application.Queries.GetReservationById;

namespace ReservationService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllReservationsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetReservationByIdQuery(id));
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReservationCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}/confirm")]
        public async Task<IActionResult> Confirm(Guid id)
        {
            await _mediator.Send(new ConfirmReservationCommand(id));
            return NoContent();
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            await _mediator.Send(new CancelReservationCommand(id));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteReservationCommand(id));
            return NoContent();
        }
    }
}
