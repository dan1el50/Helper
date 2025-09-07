using AutumnBlazorApp.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutumnBlazorApp.Application.Features.Humans
{
    public class UpdateHumanCommandHandler : IRequestHandler<UpdateHumanCommand>
    {
        private readonly ApplicationDbContext _context;

        public UpdateHumanCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateHumanCommand request, CancellationToken cancellationToken)
        {
            var human = await _context.Humans.FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

            if (human is null)
            {
                // Or handle this case as you see fit, maybe return a specific result
                throw new KeyNotFoundException($"Human with Id {request.Id} not found.");
            }

            human.Name = request.Human.Name;
            human.Surname = request.Human.Surname;
            human.DateOfBirth = request.Human.DateOfBirth;
            human.PlaceOfBirth = request.Human.PlaceOfBirth;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
