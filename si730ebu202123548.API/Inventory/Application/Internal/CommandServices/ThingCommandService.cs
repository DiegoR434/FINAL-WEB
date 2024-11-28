using si730ebu202123548.API.Inventory.Domain.Model.Aggregates;
using si730ebu202123548.API.Inventory.Domain.Model.Commands;
using si730ebu202123548.API.Inventory.Domain.Repositories;
using si730ebu202123548.API.Inventory.Domain.Services;
using si730ebu202123548.API.shared.Domain.Repositories;

namespace si730ebu202123548.API.Inventory.Application.Internal.CommandServices;

public class ThingCommandService(IThingRepository thingRepository, IUnitOfWork unitOfWork)
        :IThingCommandService
{
    public async Task<Thing?> HandleCommand(CreateThingCommand command)
    {
        var thingSerialNumberAsync = await thingRepository.FindBySerialNumberAsync(command.serialNumber);
        if (thingSerialNumberAsync != null) throw new Exception($"Thing with the serial number {command.serialNumber} already exists");
        var thing = new Thing(command);
        try
        {
            await thingRepository.AddAsync(thing);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return thing;
    }
}