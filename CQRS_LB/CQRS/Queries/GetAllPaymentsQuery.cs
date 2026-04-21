using CQRS_LB.CQRS.DTOs;
using MediatR;

namespace CQRS_LB.CQRS.Queries
{
    public record GetAllPaymentsQuery : IRequest<List<DtoAllPaymentsDetails>>
    { }

}
