using Application.Common;
using CQRS_LB.CQRS.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_LB.CQRS.Handelers
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, bool>
    {
        public DeletePaymentCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        private readonly IAppDbContext _context;
        public async Task<bool> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _context.Payments
                .FirstOrDefaultAsync(p => p.Id == request.Id);

            if (payment == null)
                return false;

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
