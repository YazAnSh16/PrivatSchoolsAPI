using MediatR;

namespace Application.Features.Students.Command.DeleteStuden
{
    public record DeleteStudentCommand(int id) : IRequest<bool>
    {
    }
}
