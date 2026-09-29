using Application.Common;
using Application.Features.Payments.Command.AddPayment;
using Application.Features.Payments.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        public async Task<PaymentDetailsResponse> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
        {
            var OldAmount = await _context.Students.Include(s => s.Payments).Where(s => s.Id == request.StudentId).FirstOrDefaultAsync(cancellationToken);

            int x = 0;

            foreach (var item in OldAmount.Payments)
            {
                x += item.Amount;
            }


            var payment = new Payment
            {
                Amount = request.Amount,
                PaidAmount = request.Amount + x,
                StudentId = request.StudentId,
                TotalAmount = request.TotalAmount,
            };


            _context.Payments.Add(payment);
            await _context.SaveChangesAsync(cancellationToken);

            return new PaymentDetailsResponse
            {
                PaymentId = payment.Id,
                Amount = payment.Amount,
                StudentId = payment.StudentId,
                PaymentDate = payment.PaymentDate,
                PaidAmount = payment.PaidAmount,
                RemainingAmount = payment.TotalAmount - payment.PaidAmount ,
                TotalAmount = payment.TotalAmount
            };
        }
    }
}
