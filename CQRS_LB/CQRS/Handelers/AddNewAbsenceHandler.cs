using CQRS_LB.CQRS.Commands;
using CQRS_LB.CQRS.DTOs;
using CQRS_LB.Data;
using CQRS_LB.Data.Models;
using MediatR;

namespace CQRS_LB.CQRS.Handelers
{


    public class AddNewAbsenceHandler : IRequestHandler<AddNewAbsenceCommand, DtoAbsenceDetails>
    {
        public AddNewAbsenceHandler(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;
        public async Task<DtoAbsenceDetails> Handle(AddNewAbsenceCommand request, CancellationToken cancellationToken)
        {
            var absence = new Absence
            {
                StudentId = request.Absence.StudentId,
                AbsenceDate = request.Absence.AbsenceDate,
                Result = request.Absence.Result

            };
            await _context.Absences.AddAsync(absence);
            await _context.SaveChangesAsync(cancellationToken);
            return new DtoAbsenceDetails
            {
                Id = absence.Id,
                StudentId = absence.StudentId,
                AbsenceDate = absence.AbsenceDate,
                Result = absence.Result
            };
        }
    }

}
