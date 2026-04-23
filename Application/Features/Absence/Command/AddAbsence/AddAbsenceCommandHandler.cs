using Application.Common;
using Application.Features.Absence.Responses;

using MediatR;
using PrivatSchoolsAPI.Domain.Entities;

namespace Application.Features.Absence.Command.AddAbsence
{


    public class AddAbsenceHandler : IRequestHandler<AddAbsenceCommand, AbsenceDetailsRespones>
    {
        public AddAbsenceHandler(IAppDbContext context)
        {
            _context = context;
        }

        private readonly IAppDbContext _context;
        public async Task<AbsenceDetailsRespones> Handle(AddAbsenceCommand request, CancellationToken cancellationToken)
        {
            var absence = new Absences
            {
                StudentId = request.StudentId,
                AbsenceDate = request.AbsenceDate,
                Result = request.Result

            };
            await _context.Absences.AddAsync(absence);
            await _context.SaveChangesAsync(cancellationToken);
            return new AbsenceDetailsRespones
            {
                Id = absence.Id,
                StudentId = absence.StudentId,
                AbsenceDate = absence.AbsenceDate,
                Result = absence.Result
            };
        }
    }

}
