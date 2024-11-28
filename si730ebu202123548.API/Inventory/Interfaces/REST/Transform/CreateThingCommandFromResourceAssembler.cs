using si730ebu202123548.API.Inventory.Domain.Model.Commands;
using si730ebu202123548.API.Inventory.Interfaces.REST.Resources;

namespace si730ebu202123548.API.Inventory.Interfaces.REST.Transform;

public static class CreateThingCommandFromResourceAssembler
{
    public static CreateThingCommand
        ToCommandFromResource(CreateThingResource resource) =>
        new CreateThingCommand(
            resource.serialNumber,
            resource.model,
            resource.operationMode,
            resource.maximumTemperatureThreshold,
            resource.minimumHumidityThreshold
        );
}