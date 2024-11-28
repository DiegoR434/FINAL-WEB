﻿namespace si730ebu202123548.API.Observability.Interfaces.REST.Resources;

public record CreateThingStateResource(
    int thingSerialNumber,
    int currentOperationMode,
    float currentTemperature,
    float currentHumidity,
    DateTimeOffset collectedAt
);