using MediatR;

namespace AutumnBlazorApp.Application.Features.Humans
{
    public record DeleteHumanCommand(int Id) : IRequest;
}
