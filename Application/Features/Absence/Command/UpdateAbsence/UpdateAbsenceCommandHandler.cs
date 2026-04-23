using Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Absence.Command.UpdateAbsence
{
    public class UpdateAbsenceCommandHandler : IRequestHandler<UpdateAbsenceCommand, bool>
    {
        public UpdateAbsenceCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        private readonly IAppDbContext _context;

        public async Task<bool> Handle(UpdateAbsenceCommand request, CancellationToken cancellationToken)
        {
            var absence = await _context.Absences.FirstOrDefaultAsync(a => a.Id == request.Id);
            if (absence == null)
            {
                return false;
            }
            else
            {
                absence.AbsenceDate = request.AbsenceDate;
                absence.Result = request.Result;

                _context.SaveChangesAsync(cancellationToken);
                return true;
            }

        }
    }
}
