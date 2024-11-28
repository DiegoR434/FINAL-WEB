
using si730ebu202123548.API.Observability.Domain.Model.Commands;

namespace si730ebu202123548.API.Observability.Domain.Model.Aggregates;

public  class ThingState
{
    public int Id { get; private set; }
    public int thingSerialNumber { get; private set; }
    public int currentOperationMode { get; private set; }
    public float currentTemperature { get; private set; }
    public float currentHumidity { get; private set; }
    
    public DateTimeOffset collectedAt { get; private set; }

    protected ThingState()
    {
        this.thingSerialNumber = 0;
        this.currentOperationMode = 0;
        this.currentTemperature = 0;
        this.currentHumidity = 0;
    }

    public ThingState(CreateThingStateCommand command)
    {
        this.thingSerialNumber = command.thingSerialNumber;
        this.currentOperationMode = command.currentOperationMode;
        this.currentTemperature = command.currentTemperature;
        this.currentHumidity = command.currentHumidity;
    }
}