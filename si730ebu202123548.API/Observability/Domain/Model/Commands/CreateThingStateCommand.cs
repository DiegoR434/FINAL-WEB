namespace si730ebu202123548.API.Observability.Domain.Model.Commands;

public record CreateThingStateCommand
(
    int thingSerialNumber,
    int currentOperationMode,
    float currentTemperature,
    float currentHumidity,
    DateTimeOffset collectedAt
);