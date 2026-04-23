using MediatR;

namespace Application.Features.Absence.Command.UpdateAbsence
{
    public record UpdateAbsenceCommand(int Id, bool Result, DateTime AbsenceDate) : IRequest<bool>
    {
    }
}
