using CQRS_LB.CQRS.Commands;
using CQRS_LB.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_LB.CQRS.Handelers
{
    public class DeletePaymentHandler : IRequestHandler<DeletePaymentCommand, bool>
    {
        public DeletePaymentHandler(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;
        public async Task<bool> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _context.Payments
                .FirstOrDefaultAsync(p => p.Id == request.Id);

            if (payment == null)
                return false;

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
