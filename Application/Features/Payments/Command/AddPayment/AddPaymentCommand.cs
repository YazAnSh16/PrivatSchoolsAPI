using Application.Features.Payments.Responses;
using MediatR;

namespace Application.Features.Payments.Command.AddPayment
{
    public record AddPaymentCommand(Guid StudentId, int Amount, int TotalAmount) : IRequest<PaymentDetailsResponse>
    {
    }
}
