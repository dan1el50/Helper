using AutumnBlazorApp.Shared.DTOs;
using MediatR;

namespace AutumnBlazorApp.Application.Features.Humans
{
    public record GetAllHumansQuery : IRequest<List<HumanDto>>;
}
