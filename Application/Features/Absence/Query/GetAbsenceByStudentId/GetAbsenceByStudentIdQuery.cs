using Application.Features.Absence.Responses;
using MediatR;

namespace Application.Features.Absence.Query.GetAbsenceByStudentId
{
    public record GetAbsenceByStudentIdQuery(Guid Id) : IRequest<List<AbsenceDetailsRespones>>;
}
