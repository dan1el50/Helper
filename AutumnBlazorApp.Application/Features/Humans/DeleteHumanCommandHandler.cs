using AutumnBlazorApp.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutumnBlazorApp.Application.Features.Humans
{
    public class DeleteHumanCommandHandler : IRequestHandler<DeleteHumanCommand>
    {
        private readonly ApplicationDbContext _context;

        public DeleteHumanCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteHumanCommand request, CancellationToken cancellationToken)
        {
            var human = await _context.Humans.FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

            if (human is not null)
            {
                _context.Humans.Remove(human);
                await _context.SaveChangesAsync(cancellationToken);
            }
            // If the human is null, we can choose to do nothing, as the desired state (non-existence) is already achieved.
        }
    }
}
