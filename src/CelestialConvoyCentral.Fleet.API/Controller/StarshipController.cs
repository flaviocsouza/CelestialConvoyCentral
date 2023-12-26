using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CelestialConvoyCentral.Fleet.API;

[ApiController]
public class StarshipController : CoreController
{
    public StarshipController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStarshipCommand command)
    {
        return Ok();
    }
}
