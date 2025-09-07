using AutumnBlazorApp.Application.Features.Humans;
using AutumnBlazorApp.Shared.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutumnBlazorApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HumansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HumansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/humans
        [HttpGet]
        public async Task<ActionResult<List<HumanDto>>> GetAllHumans()
        {
            var humans = await _mediator.Send(new GetAllHumansQuery());
            return Ok(humans);
        }

        // GET: api/humans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HumanDto>> GetHumanById(int id)
        {
            var human = await _mediator.Send(new GetHumanByIdQuery(id));
            return human is not null ? Ok(human) : NotFound();
        }

        // POST: api/humans
        [HttpPost]
        public async Task<ActionResult<int>> CreateHuman([FromBody] HumanDto human)
        {
            var newHumanId = await _mediator.Send(new CreateHumanCommand(human));
            return CreatedAtAction(nameof(GetHumanById), new { id = newHumanId }, newHumanId);
        }

        // PUT: api/humans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHuman(int id, [FromBody] HumanDto human)
        {
            // We use the id from the route to ensure we're updating the correct resource.
            await _mediator.Send(new UpdateHumanCommand(id, human));
            return NoContent(); // Indicates success with no content to return.
        }

        // DELETE: api/humans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHuman(int id)
        {
            await _mediator.Send(new DeleteHumanCommand(id));
            return NoContent();
        }
    }
}
