using Application.Common;
using Application.Features.Payments.Queries.GetPayments;
using Application.Features.Payments.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_LB.CQRS.Handelers
{
    public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, List<AllPaymentsDetailsResponse>>
    {

        public GetAllPaymentsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        private readonly IAppDbContext _context;
        public async Task<List<AllPaymentsDetailsResponse>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Payments
            .Include(p => p.Student)
                .Select(p => new AllPaymentsDetailsResponse
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
