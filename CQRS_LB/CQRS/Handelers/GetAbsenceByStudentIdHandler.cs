using CQRS_LB.CQRS.DTOs;
using CQRS_LB.CQRS.Queries;
using CQRS_LB.Data;
using MediatR;

namespace CQRS_LB.CQRS.Handelers
{
    public class GetAbsenceByStudentIdHandler : IRequestHandler<GetAbsenceByStudentIdQuery, List<DtoAbsenceDetails>>
    {

        public GetAbsenceByStudentIdHandler(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;
        public Task<List<DtoAbsenceDetails>> Handle(GetAbsenceByStudentIdQuery request, CancellationToken cancellationToken)
        {
            var absences = _context.Absences.Where(x => x.StudentId == request.Id).Select(x => new DtoAbsenceDetails
            {
                Id = x.Id,
                AbsenceDate = x.AbsenceDate,
                Result = x.Result,
                StudentId = x.StudentId
            }).ToList();
            return Task.FromResult(absences);
        }
    }
}
