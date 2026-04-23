using Application.Common;
using Application.Features.Payments.Responses;
using MediatR;

namespace Application.Features.Payments.Queries.GetPaymentById
{

    public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentsByIdQuery, List<PaymentDetailsResponse>>
    {
        public GetPaymentByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        private readonly IAppDbContext _context;
        public Task<List<PaymentDetailsResponse>> Handle(GetPaymentsByIdQuery request, CancellationToken cancellationToken)
        {
            var payments = _context.Payments
       .Where(p => p.StudentId == request.Id)
       .Select(p => new PaymentDetailsResponse
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