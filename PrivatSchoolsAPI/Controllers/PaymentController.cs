using CQRS_LB.CQRS.Commands;
using CQRS_LB.CQRS.DTOs;
using CQRS_LB.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PrivatSchoolsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        [HttpGet]
        public async Task<IActionResult> GetAllPaymnents()
        {
            var result = await _mediator.Send(new GetAllPaymentsQuery());
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetPaymentsByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddPayments([FromBody] DtoNewPayment payment)
        {
            var result = await _mediator.Send(new AddNewPaymentCommand(payment));
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var result = await _mediator.Send(new DeletePaymentCommand(id));

            if (!result)
                return NotFound();

            return Ok("removed"); // 200
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, [FromBody] DtoUpdatePayment payment)
        {
            var result = await _mediator.Send(new UpdatePaymentCommand(id, payment));
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
