using CQRS_LB.CQRS.DTOs;
using MediatR;

namespace CQRS_LB.CQRS.Commands
{
    public record UpdatePaymentCommand(int id, DtoUpdatePayment Payment) : IRequest<bool>
    {
    }
}
