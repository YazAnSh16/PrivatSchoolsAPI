using MediatR;

namespace Application.Features.Payments.Command.UpdatePayment
{
    public record UpdatePaymentCommand(
        int id, decimal Amount, decimal TotalAmount, DateTime PaymentDate) :
        IRequest<bool>
    { }


}
