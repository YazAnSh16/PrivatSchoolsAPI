using Application.Features.Payments.Responses;
using MediatR;

namespace Application.Features.Payments.Command.AddPayment
{
    public record AddPaymentCommand(int StudentId, decimal Amount, decimal TotalAmount) : IRequest<PaymentDetailsResponse>
    {
    }
}
