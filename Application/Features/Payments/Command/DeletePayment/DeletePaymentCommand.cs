using MediatR;

namespace CQRS_LB.CQRS.Commands
{
    public record DeletePaymentCommand(int Id) : IRequest<bool>;
}
