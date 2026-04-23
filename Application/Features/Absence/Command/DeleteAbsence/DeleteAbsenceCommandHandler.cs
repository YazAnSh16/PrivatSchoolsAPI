using Application.Common;
using CQRS_LB.CQRS.Commands;

using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_LB.CQRS.Handelers
{
    public class DeleteAbsenceHandler : IRequestHandler<DeleteAbsenceCommand, bool>
    {
        public DeleteAbsenceHandler(IAppDbContext context)
        {
            _context = context;
        }

        private readonly IAppDbContext _context;

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
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
    }
}
