using CQRS_LB.CQRS.DTOs;
using CQRS_LB.CQRS.Queries;
using CQRS_LB.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_LB.CQRS.Handelers
{
    public class GetAllPaymentsHandler : IRequestHandler<GetAllPaymentsQuery, List<DtoAllPaymentsDetails>>
    {

        public GetAllPaymentsHandler(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;
        public async Task<List<DtoAllPaymentsDetails>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Payments
            .Include(p => p.Student)
                .Select(p => new DtoAllPaymentsDetails
                {
                    PaymentId = p.Id,
                    StudentId = p.StudentId,
                    StudentName = p.Student.Name,
                    Amount = p.Amount,
                    TotalAmount = p.TotalAmount,
                    PaymentDate = p.PaymentDate
                })
            .ToListAsync();
            return result;

        }
    }
}
