using AutumnBlazorApp.Infrastructure.Data;
using AutumnBlazorApp.Shared.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutumnBlazorApp.Application.Features.Humans
{
    public class GetAllHumansQueryHandler : IRequestHandler<GetAllHumansQuery, List<HumanDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllHumansQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HumanDto>> Handle(GetAllHumansQuery request, CancellationToken cancellationToken)
        {
            var humans = await _context.Humans
                .Select(h => new HumanDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    Surname = h.Surname,
                    DateOfBirth = h.DateOfBirth,
                    PlaceOfBirth = h.PlaceOfBirth,
                    Age = h.Age // The calculated property from our Domain model is used here!
                })
                .ToListAsync(cancellationToken);

            return humans;
        }
    }
}
