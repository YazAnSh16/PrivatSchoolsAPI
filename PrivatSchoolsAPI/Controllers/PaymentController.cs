using Application.Features.Payments.Command.AddPayment;
using Application.Features.Payments.Command.UpdatePayment;
using Application.Features.Payments.Queries.GetPaymentById;
using Application.Features.Payments.Queries.GetPayments;
using CQRS_LB.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrivatSchoolsAPI.API.Requests.Payment;

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


        /// <summary>
        /// Get all payments from the system
        /// </summary>
        /// <returns>List of all payments</returns>
        /// <response code="200">Returns list of payments</response>
        [HttpGet]
        public async Task<IActionResult> GetAllPaymnents()
        {
            var result = await _mediator.Send(new GetAllPaymentsQuery());
            return Ok(result);
        }

        /// <summary>
        /// Get payment by unique identifier
        /// </summary>
        /// <param name="id">Payment ID</param>
        /// <returns>Payment details</returns>
        /// <response code="200">Payment found</response>
        /// <response code="404">Payment not found</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetPaymentsByIdQuery(id));
            return Ok(result);
        }

        /// <summary>
        /// Create a new payment
        /// </summary>
        /// <param name="payment">Payment data</param>
        /// <returns>Created payment result</returns>
        /// <response code="200">Payment created successfully</response>
        [HttpPost]
        public async Task<IActionResult> AddPayments(AddPaymentRequest payment)
        {
            var command = new AddPaymentCommand(payment.StudentId,
                payment.Amount,
                payment.TotalAmount);

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Delete a payment by ID
        /// </summary>
        /// <param name="id">Payment ID</param>
        /// <response code="204">Deleted successfully</response>
        /// <response code="404">Payment not found</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var result = await _mediator.Send(new DeletePaymentCommand(id));

            if (!result)
                return NotFound();

            return Ok("removed"); // 200
        }

        /// <summary>
        /// Update an existing payment
        /// </summary>
        /// <param name="id">Payment ID</param>
        /// <param name="payment">Updated payment data</param>
        /// <response code="200">Updated successfully</response>
        /// <response code="404">Payment not found</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, UpdatePaymentRequest payment)
        {
            var command = new UpdatePaymentCommand(id, payment.Amount, payment.TotalAmount, payment.PaymentDate);

            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
