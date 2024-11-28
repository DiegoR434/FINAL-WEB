using si730ebu202123548.API.Observability.Domain.Model.Aggregates;
using si730ebu202123548.API.Observability.Interfaces.REST.Resources;

namespace si730ebu202123548.API.Observability.Interfaces.REST.Transform;

public class ThingStateResourceFromEntityAssembler
{
    public static ThingStateResource
        ToResourceFromEntity(ThingState thingState) =>
        new ThingStateResource(
            thingState.Id,
            thingState.thingSerialNumber,
            thingState.currentOperationMode,
            thingState.currentTemperature,
            thingState.currentHumidity,
            thingState.collectedAt
        );
}