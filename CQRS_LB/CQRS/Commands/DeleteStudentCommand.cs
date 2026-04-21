using MediatR;

namespace CQRS_LB.CQRS.Commands
{
    public record DeleteStudentCommand(int id) : IRequest<bool>
    {
    }
}
