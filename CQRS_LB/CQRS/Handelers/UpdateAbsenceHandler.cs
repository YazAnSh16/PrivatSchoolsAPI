using CQRS_LB.CQRS.Commands;
using CQRS_LB.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_LB.CQRS.Handelers
{
    public class UpdateAbsenceHandler : IRequestHandler<UpdateAbsenceCommand, bool>
    {
        public UpdateAbsenceHandler(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;

        public async Task<bool> Handle(UpdateAbsenceCommand request, CancellationToken cancellationToken)
        {
            var absence = await _context.Absences.FirstOrDefaultAsync(a => a.Id == request.Absence.Id);
            if (absence == null)
            {
                return false;
            }
            else
            {
                absence.AbsenceDate = request.Absence.AbsenceDate;
                absence.Result = request.Absence.Result;

                _context.SaveChanges();
                return true;
            }

        }
    }
}
