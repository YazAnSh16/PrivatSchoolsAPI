using MediatR;
using PrivatSchoolsAPI.Domain.Entities;

namespace Application.Features.Students.Queries.GetAllStudents
{
    public record GetAllStudentsQuery : IRequest<List<Student>>
    {
    }
}
