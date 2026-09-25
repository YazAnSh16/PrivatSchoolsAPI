using MediatR;

namespace Application.Features.Payments.Command.UpdatePayment
{
    public record UpdatePaymentCommand(
        Guid id, decimal Amount, decimal TotalAmount, DateTime PaymentDate) :
        IRequest<bool>
    { }


}
