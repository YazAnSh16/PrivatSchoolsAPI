using Application.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TestResults.Command.DeleteTestResult
{
    public class DeleteTestResultCommandHandler : IRequestHandler<DeleteTestResultCommand, bool>
        {
        private readonly IAppDbContext _context;

        public DeleteTestResultCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteTestResultCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TestResults.FindAsync(request.Id , cancellationToken);
            if (entity == null) return false;

            _context.TestResults.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
