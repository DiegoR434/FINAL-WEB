using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730ebu202123548.API.Inventory.Domain.Model.Queries;
using si730ebu202123548.API.Inventory.Domain.Services;
using si730ebu202123548.API.Inventory.Interfaces.REST.Resources;
using si730ebu202123548.API.Inventory.Interfaces.REST.Transform;

namespace si730ebu202123548.API.Inventory.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class ThingsController(
    IThingCommandService thingCommandService,
    IThingQueryService thingQueryService
    )
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateThing([FromBody] CreateThingResource resource)
    {
        var createThingCommand = CreateThingCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await thingCommandService.HandleCommand(createThingCommand);
        if(result is null) return BadRequest();
        return CreatedAtAction(
            nameof(GetThingById),
            new{id = result.Id}, 
            ThingResourceFromEntityAssembler.ToResourceFromEntity(result)
            );
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetThingById(int id)
    {
        var getThingByIdQuery = new GetThingByIdQuery(id);
        var result = await thingQueryService.HandleQueryId(getThingByIdQuery);
        if (result is null) return NotFound();
        var resource = ThingResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}