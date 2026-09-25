using Application.Features.Students.Responses;
using MediatR;

namespace Application.Features.Students.Queries.GetStudentById
{
    public record GetStudentByIdQuery(Guid Id) : IRequest<StudentDetailsResponse>;
}
