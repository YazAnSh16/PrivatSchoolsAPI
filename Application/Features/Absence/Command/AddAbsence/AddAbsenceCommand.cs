using Application.Features.Absence.Responses;
using MediatR;

namespace Application.Features.Absence.Command.AddAbsence
{
    public record AddAbsenceCommand(bool Result, int StudentId, DateTime AbsenceDate) : IRequest<AbsenceDetailsRespones>
    {

    }
}
