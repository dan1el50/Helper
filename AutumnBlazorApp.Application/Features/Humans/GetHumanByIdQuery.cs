using AutumnBlazorApp.Shared.DTOs;
using MediatR;

namespace AutumnBlazorApp.Application.Features.Humans
{
    public record GetHumanByIdQuery(int Id) : IRequest<HumanDto?>;
}
