using si730ebu202123548.API.Inventory.Domain.Model.Aggregates;
using si730ebu202123548.API.Inventory.Interfaces.REST.Resources;

namespace si730ebu202123548.API.Inventory.Interfaces.REST.Transform;

public static class ThingResourceFromEntityAssembler
{
    public static ThingResource ToResourceFromEntity(Thing thing) =>
        new ThingResource(
            thing.Id,
            thing.serialNumber,
            thing.model,
            thing.operationMode,
            thing.maximumTemperatureThreshold,
            thing.minimumHumidityThreshold
        );
}