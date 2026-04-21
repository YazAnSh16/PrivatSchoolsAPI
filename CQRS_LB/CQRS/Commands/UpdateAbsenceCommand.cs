using CQRS_LB.CQRS.DTOs;
using MediatR;

namespace CQRS_LB.CQRS.Commands
{
    public record UpdateAbsenceCommand(DtoUpdateAbsence absence) : IRequest<bool>
    {
    }
}
