using si730ebu202123548.API.Inventory.Domain.ValueObjects;

namespace si730ebu202123548.API.Inventory.Domain.Model.Commands;

public record CreateThingCommand(
    int serialNumber,
    string model,
    EOperationMode operationMode,
    float maximumTemperatureThreshold,
    float minimumHumidityThreshold
);