using MediatR;

namespace CQRS_LB.CQRS.Commands
{
    public record DeleteAbsenceCommand(int Id) : IRequest<bool>
    {
    }
}
