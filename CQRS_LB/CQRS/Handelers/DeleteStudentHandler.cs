using CQRS_LB.CQRS.Commands;
using CQRS_LB.Data;
using MediatR;

namespace CQRS_LB.CQRS.Handelers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        public DeleteStudentHandler(AppDbContext context)
        {
            _context = context;
        }
        private readonly AppDbContext _context;

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
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
