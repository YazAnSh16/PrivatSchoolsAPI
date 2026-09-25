using MediatR;

namespace Application.Features.Absence.Command.UpdateAbsence
{
    public record UpdateAbsenceCommand(Guid Id, bool Result, DateTime AbsenceDate) : IRequest<bool>
    {
    }
}
