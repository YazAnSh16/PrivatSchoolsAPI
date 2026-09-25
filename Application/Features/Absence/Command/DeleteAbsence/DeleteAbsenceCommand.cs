using MediatR;

namespace CQRS_LB.CQRS.Commands
{
    public record DeleteAbsenceCommand(Guid Id) : IRequest<bool>
    {
    }
}
