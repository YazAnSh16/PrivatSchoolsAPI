using Application.Features.Absence.Responses;
using MediatR;

namespace Application.Features.Absence.Query.GetAbsenceByStudentId
{
    public record GetAbsenceByStudentIdQuery(int Id) : IRequest<List<AbsenceDetailsRespones>>;
}
