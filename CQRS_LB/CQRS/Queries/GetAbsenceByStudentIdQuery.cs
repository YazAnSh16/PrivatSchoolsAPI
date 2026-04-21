using CQRS_LB.CQRS.DTOs;
using MediatR;

namespace CQRS_LB.CQRS.Queries
{
    public record GetAbsenceByStudentIdQuery(int Id) : IRequest<List<DtoAbsenceDetails>>;
}
