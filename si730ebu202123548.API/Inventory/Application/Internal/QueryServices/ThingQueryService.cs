using si730ebu202123548.API.Inventory.Domain.Model.Aggregates;
using si730ebu202123548.API.Inventory.Domain.Model.Queries;
using si730ebu202123548.API.Inventory.Domain.Repositories;
using si730ebu202123548.API.Inventory.Domain.Services;

namespace si730ebu202123548.API.Inventory.Application.Internal.QueryServices;

public class ThingQueryService(IThingRepository thingRepository)
            :IThingQueryService
{
    public async Task<Thing?> HandleQueryId(GetThingByIdQuery query)
    {
        return await thingRepository.FindByIdAsync(query.Id);
    }

    public async Task<Thing?> HandleQuerySerialNumber(GetThingBySerialNumberQuery query)
    {
        return await thingRepository.FindBySerialNumberAsync(query.serialNumber);
    }
}