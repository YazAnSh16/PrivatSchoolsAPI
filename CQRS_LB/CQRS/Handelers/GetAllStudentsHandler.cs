using CQRS_LB.CQRS.Queries;
using CQRS_LB.Data;
using CQRS_LB.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_LB.CQRS.Handelers
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, List<Student>>
    {

        public GetAllStudentsHandler(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;
        public async Task<List<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students.ToListAsync();


        }
    }
}
