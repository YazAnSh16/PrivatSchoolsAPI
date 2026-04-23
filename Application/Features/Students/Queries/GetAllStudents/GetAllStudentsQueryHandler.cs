using Application.Common;
using Application.Features.Students.Queries.GetAllStudents;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PrivatSchoolsAPI.Domain.Entities;

namespace Application.Features.Students.Handelers.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<Student>>
    {

        public GetAllStudentsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        private readonly IAppDbContext _context;
        public async Task<List<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students.ToListAsync(cancellationToken);
        }
    }
}
