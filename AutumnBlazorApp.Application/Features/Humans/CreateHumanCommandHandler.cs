using AutumnBlazorApp.Domain;
using AutumnBlazorApp.Infrastructure.Data;
using MediatR;

namespace AutumnBlazorApp.Application.Features.Humans
{
    public class CreateHumanCommandHandler : IRequestHandler<CreateHumanCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateHumanCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateHumanCommand request, CancellationToken cancellationToken)
        {
            var human = new Human
            {
                Name = request.Human.Name,
                Surname = request.Human.Surname,
                DateOfBirth = request.Human.DateOfBirth,
                PlaceOfBirth = request.Human.PlaceOfBirth
            };

            _context.Humans.Add(human);
            await _context.SaveChangesAsync(cancellationToken);

            return human.Id;
        }
    }
}
