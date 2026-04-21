using CQRS_LB.CQRS.Commands;
using CQRS_LB.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_LB.CQRS.Handelers
{
    public class UpdatePaymentHandler : IRequestHandler<UpdatePaymentCommand, bool>
    {
        public UpdatePaymentHandler(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;

        public async Task<bool> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _context.Payments
            .FirstOrDefaultAsync(p => p.Id == request.id);

            if (payment == null)
                return false;

            payment.Amount = request.Payment.Amount;
            payment.PaymentDate = request.Payment.PaymentDate;
            payment.TotalAmount = request.Payment.TotalAmount;



            await _context.SaveChangesAsync();
            return true;

        }
    }
}
