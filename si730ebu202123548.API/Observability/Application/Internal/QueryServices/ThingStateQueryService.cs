using si730ebu202123548.API.Observability.Domain.Model.Aggregates;
using si730ebu202123548.API.Observability.Domain.Model.Queries;
using si730ebu202123548.API.Observability.Domain.Repositories;
using si730ebu202123548.API.Observability.Domain.Services;

namespace si730ebu202123548.API.Observability.Application.Internal.QueryServices;

public class ThingStateQueryService(IThingStateRepository thingStateRepository)
            :IThingStateQueryService
{
    public async Task<ThingState?> HandleQueryId(GetThingStateByIdQuery query)
    {
        return await thingStateRepository.FindByIdAsync(query.Id);
    }
    
}