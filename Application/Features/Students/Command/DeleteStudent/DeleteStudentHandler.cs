
using Application.Common;
using Application.Features.Students.Command.DeleteStuden;
using MediatR;

namespace Application.Features.Students.Command.DeleteStudent
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        public DeleteStudentHandler(IAppDbContext context)
        {
            _context = context;
        }
        private readonly IAppDbContext _context;

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(request.id);
            if (student == null)
            {
                return false;
            }
            else
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
    }
}
