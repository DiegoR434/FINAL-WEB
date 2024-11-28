using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730ebu202123548.API.Observability.Domain.Model.Queries;
using si730ebu202123548.API.Observability.Domain.Services;
using si730ebu202123548.API.Observability.Interfaces.REST.Resources;
using si730ebu202123548.API.Observability.Interfaces.REST.Transform;

namespace si730ebu202123548.API.Observability.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class ThingStatesController(
    IThingStateCommandService thingStateCommandService,
    IThingStateQueryService thingStateQueryService
    )
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateThingStatus([FromBody] CreateThingStateResource resource)
    {
        var createThingStateCommand = CreateThingStateCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await thingStateCommandService.HandleCommand(createThingStateCommand);
        if(result is null) return BadRequest();
        return CreatedAtAction(nameof(GetThingStateByIdQuery), 
            new { id = result.Id }, 
            ThingStateResourceFromEntityAssembler.ToResourceFromEntity(result)
            );
    }
}