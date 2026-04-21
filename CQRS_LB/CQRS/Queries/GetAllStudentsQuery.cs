using CQRS_LB.Data.Models;
using MediatR;

namespace CQRS_LB.CQRS.Queries
{
    public record GetAllStudentsQuery : IRequest<List<Student>>
    {
    }
}
