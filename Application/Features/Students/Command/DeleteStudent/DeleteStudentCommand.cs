using MediatR;

namespace Application.Features.Students.Command.DeleteStudent
{
    public record DeleteStudentCommand(Guid Id) : IRequest<bool>
    {
    }
}
