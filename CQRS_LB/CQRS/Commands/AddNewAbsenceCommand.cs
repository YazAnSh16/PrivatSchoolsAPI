using CQRS_LB.CQRS.DTOs;
using MediatR;

namespace CQRS_LB.CQRS.Commands
{
    public record AddNewAbsenceCommand(DtoNewAbsence Absence) : IRequest<DtoAbsenceDetails>
    {
    }
}
