using si730ebu202123548.API.Inventory.Domain.Model.Commands;
using si730ebu202123548.API.Inventory.Domain.ValueObjects;

namespace si730ebu202123548.API.Inventory.Domain.Model.Aggregates;

public  class Thing
{
    public int Id { get; private set; }
    public int serialNumber { get; private set; }
    public string model { get; private set; }
    public EOperationMode operationMode { get; private set; }
    public float maximumTemperatureThreshold { get; private set; }
    public float minimumHumidityThreshold { get; private set; }

    protected Thing()
    {
        this.serialNumber = 0;
        this.model = string.Empty;
        this.operationMode = 0;
        this.maximumTemperatureThreshold = 0;
        this.minimumHumidityThreshold = 0;
    }

    public Thing(CreateThingCommand command)
    {
        this.serialNumber = command.serialNumber;
        this.model = command.model;
        this.operationMode = command.operationMode;
        this.maximumTemperatureThreshold = command.maximumTemperatureThreshold;
        this.minimumHumidityThreshold = command.minimumHumidityThreshold;
    }
    
}