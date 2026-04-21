using CQRS_LB.CQRS.DTOs;
using MediatR;

namespace CQRS_LB.CQRS.Commands
{
    public record UpdateStudentCommand(int id, DtoUpdateStudent Student) : IRequest<bool>
    {
    }
}
