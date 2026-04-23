using Application.Common;
using Application.Features.Payments.Command.AddPayment;
using Application.Features.Payments.Responses;
using MediatR;
using PrivatSchoolsAPI.Domain.Entities;

namespace PrivatSchoolsAPI.Application.Features.Payments.Command.AddPayment
{
    public class AddPaymentCommandHandler : IRequestHandler<AddPaymentCommand, PaymentDetailsResponse>
    {

        public AddPaymentCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        private readonly IAppDbContext _context;
        public Task<PaymentDetailsResponse> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = new Payment
            {
                Amount = request.Amount,
                StudentId = request.StudentId,
                TotalAmount = request.TotalAmount,
            };

            _context.Payments.Add(payment);
            _context.SaveChangesAsync(cancellationToken);

            return Task.FromResult(new PaymentDetailsResponse
            {
                PaymentId = payment.Id,
                Amount = payment.Amount,
                StudentId = payment.StudentId,
                PaymentDate = payment.PaymentDate,
                TotalAmount = payment.TotalAmount
            });
        }
    }
}
