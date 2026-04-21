using CQRS_LB.CQRS.Commands;
using CQRS_LB.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_LB.CQRS.Handelers
{
    public class DeleteAbsenceHandler : IRequestHandler<DeleteAbsenceCommand, bool>
    {
        public DeleteAbsenceHandler(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;

        public async Task<bool> Handle(DeleteAbsenceCommand request, CancellationToken cancellationToken)
        {
            var absence = await _context.Absences.FirstOrDefaultAsync(a => a.Id == request.Id);
            if (absence == null)
            {
                return false;
            }
            else
            {
                _context.Absences.Remove(absence);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
