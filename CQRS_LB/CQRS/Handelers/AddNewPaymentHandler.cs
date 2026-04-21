using CQRS_LB.CQRS.Commands;
using CQRS_LB.CQRS.DTOs;
using CQRS_LB.Data;
using CQRS_LB.Data.Models;
using MediatR;

namespace CQRS_LB.CQRS.Handelers
{
    public class AddNewPaymentHandler : IRequestHandler<AddNewPaymentCommand, DtoPaymentDetails>
    {

        public AddNewPaymentHandler(AppDbContext context)
        {
            _context = context;
        }
        private readonly AppDbContext _context;
        public Task<DtoPaymentDetails> Handle(AddNewPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = new Payments
            {
                Amount = request.Payment.Amount,
                StudentId = request.Payment.StudentId,
                TotalAmount = request.Payment.TotalAmount,
            };

            _context.Payments.Add(payment);
            _context.SaveChanges();

            return Task.FromResult(new DtoPaymentDetails
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
