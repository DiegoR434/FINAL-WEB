using si730ebu202123548.API.Inventory.Domain.Model.Aggregates;
using si730ebu202123548.API.Inventory.Domain.Model.Queries;

namespace si730ebu202123548.API.Inventory.Domain.Services;

public interface IThingQueryService
{
    Task<Thing?> HandleQueryId(GetThingByIdQuery query);
    Task<Thing?> HandleQuerySerialNumber(GetThingBySerialNumberQuery query);
}