using si730ebu202123548.API.Observability.Domain.Model.Aggregates;
using si730ebu202123548.API.Observability.Domain.Model.Queries;

namespace si730ebu202123548.API.Observability.Domain.Services;

public interface IThingStateQueryService
{
    Task<ThingState?> HandleQueryId(GetThingStateByIdQuery query);
}