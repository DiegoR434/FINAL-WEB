using si730ebu202123548.API.Inventory.Domain.Model.Aggregates;
using si730ebu202123548.API.Inventory.Domain.Model.Commands;

namespace si730ebu202123548.API.Inventory.Domain.Services;

public interface IThingCommandService
{
    Task<Thing?> HandleCommand(CreateThingCommand command);
}