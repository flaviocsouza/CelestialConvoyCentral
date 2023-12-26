using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CelestialConvoyCentral.Fleet.API;

public class CoreController : ControllerBase
{
    readonly protected IMediator _mediator;

    public CoreController(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected async Task PublishEvent<TMessage>(TMessage message)
    {
        await _mediator.Publish(message);
    }
}
