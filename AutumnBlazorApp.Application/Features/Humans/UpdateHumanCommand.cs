using AutumnBlazorApp.Shared.DTOs;
using MediatR;

namespace AutumnBlazorApp.Application.Features.Humans
{
    public record UpdateHumanCommand(int Id, HumanDto Human) : IRequest;
}
