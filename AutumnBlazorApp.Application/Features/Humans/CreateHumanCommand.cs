using AutumnBlazorApp.Shared.DTOs;
using MediatR;

namespace AutumnBlazorApp.Application.Features.Humans
{
    public record CreateHumanCommand(HumanDto Human) : IRequest<int>;
}
