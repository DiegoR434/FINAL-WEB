using si730ebu202123548.API.Inventory.Domain.ValueObjects;

namespace si730ebu202123548.API.Inventory.Interfaces.REST.Resources;

public record CreateThingResource(
    int serialNumber,
    string model,
    EOperationMode operationMode,
    float maximumTemperatureThreshold,
    float minimumHumidityThreshold
    );