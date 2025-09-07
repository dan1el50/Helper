using AutumnBlazorApp.Infrastructure.Data;
using AutumnBlazorApp.Shared.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutumnBlazorApp.Application.Features.Humans
{
    public class GetHumanByIdQueryHandler : IRequestHandler<GetHumanByIdQuery, HumanDto?>
    {
        private readonly ApplicationDbContext _context;

        public GetHumanByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HumanDto?> Handle(GetHumanByIdQuery request, CancellationToken cancellationToken)
        {
            var human = await _context.Humans
                .Where(h => h.Id == request.Id)
                .Select(h => new HumanDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    Surname = h.Surname,
                    DateOfBirth = h.DateOfBirth,
                    PlaceOfBirth = h.PlaceOfBirth,
                    Age = h.Age
                })
                .FirstOrDefaultAsync(cancellationToken);

            return human;
        }
    }
}
