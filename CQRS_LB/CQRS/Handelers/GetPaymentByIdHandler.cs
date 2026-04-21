using CQRS_LB.CQRS.DTOs;
using CQRS_LB.CQRS.Queries;
using CQRS_LB.Data;
using MediatR;

namespace CQRS_LB.CQRS.Handelers
{
    public class GetPaymentByIdHandler : IRequestHandler<GetPaymentsByIdQuery, List<DtoPaymentDetails>>
    {
        public GetPaymentByIdHandler(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;
        public Task<List<DtoPaymentDetails>> Handle(GetPaymentsByIdQuery request, CancellationToken cancellationToken)
        {
            var payments = _context.Payments
       .Where(p => p.StudentId == request.Id)
       .Select(p => new DtoPaymentDetails
       {
           PaymentId = p.Id,
           StudentId = p.StudentId,
           Amount = p.Amount,
           TotalAmount = p.TotalAmount,
           PaymentDate = p.PaymentDate
       })
       .ToList();

            return Task.FromResult(payments);
        }
    }
}
