using Application.Features.Students.Responses;
using MediatR;

namespace Application.Features.Students.Queries.GetStudentById
{
    public record GetStudentByIdQuery(int Id) : IRequest<StudentDetailsResponse>;
}
