using si730ebu202123548.API.Observability.Domain.Model.Aggregates;
using si730ebu202123548.API.Observability.Domain.Model.Commands;

namespace si730ebu202123548.API.Observability.Domain.Services;

public interface IThingStateCommandService
{
    Task<ThingState?> HandleCommand(CreateThingStateCommand command);
}