using Application.Common;
using Application.Features.Payments.Command.UpdatePayment;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_LB.CQRS.Handelers
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, bool>
    {
        public UpdatePaymentCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        private readonly IAppDbContext _context;

        public async Task<bool> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _context.Payments
            .FirstOrDefaultAsync(p => p.Id == request.id);

            if (payment == null)
                return false;

            payment.Amount = request.Amount;
            payment.PaymentDate = request.PaymentDate;
            payment.TotalAmount = request.TotalAmount;



            await _context.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
