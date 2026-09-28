using MediatR;

namespace Application.Features.Payments.Command.UpdatePayment
{
    public record UpdatePaymentCommand(
        Guid id, int Amount, int TotalAmount, DateTime PaymentDate) :
        IRequest<bool>
    { }


}
