using Application.Features.Absence.Responses;
using MediatR;

namespace Application.Features.Absence.Command.AddAbsence
{
    public record AddAbsenceCommand(bool Result, Guid StudentId, DateTime AbsenceDate) : IRequest<AbsenceDetailsRespones>
    {

    }
}
