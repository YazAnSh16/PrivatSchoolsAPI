using CQRS_LB.CQRS.DTOs;
using MediatR;

namespace CQRS_LB.CQRS.Commands
{
    public record AddNewPaymentCommand(DtoNewPayment Payment) : IRequest<DtoPaymentDetails>
    {
    }
}
