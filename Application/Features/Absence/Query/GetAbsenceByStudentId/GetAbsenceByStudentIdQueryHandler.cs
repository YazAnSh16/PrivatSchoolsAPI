

using Application.Common;
using Application.Features.Absence.Responses;
using MediatR;

namespace Application.Features.Absence.Query.GetAbsenceByStudentId
{
    public class GetAbsenceByStudentIdQueryHandler : IRequestHandler<GetAbsenceByStudentIdQuery, List<AbsenceDetailsRespones>>
    {

        public GetAbsenceByStudentIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        private readonly IAppDbContext _context;
        public Task<List<AbsenceDetailsRespones>> Handle(GetAbsenceByStudentIdQuery request, CancellationToken cancellationToken)
        {
            var absences = _context.Absences.Where(x => x.StudentId == request.Id).Select(x => new AbsenceDetailsRespones
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
