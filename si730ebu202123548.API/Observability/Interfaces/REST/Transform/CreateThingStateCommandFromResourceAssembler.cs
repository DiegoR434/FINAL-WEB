using si730ebu202123548.API.Observability.Domain.Model.Commands;
using si730ebu202123548.API.Observability.Interfaces.REST.Resources;

namespace si730ebu202123548.API.Observability.Interfaces.REST.Transform;

public static class CreateThingStateCommandFromResourceAssembler
{
    public static CreateThingStateCommand
        ToCommandFromResource(CreateThingStateResource resource) =>
        new CreateThingStateCommand(
            resource.thingSerialNumber,
            resource.currentOperationMode,
            resource.currentHumidity,
            resource.currentTemperature,
            resource.collectedAt
        );
}