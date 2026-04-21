using CQRS_LB.CQRS.DTOs;
using MediatR;

namespace CQRS_LB.CQRS.Commands
{
    public record AddNewStudentCommand(DtoNewStudent Student) : IRequest<DtoStudentDetails>
    {
    }
}
