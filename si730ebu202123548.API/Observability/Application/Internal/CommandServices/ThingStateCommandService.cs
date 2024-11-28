using System.ComponentModel;
using si730ebu202123548.API.Observability.Domain.Model.Aggregates;
using si730ebu202123548.API.Observability.Domain.Model.Commands;
using si730ebu202123548.API.Observability.Domain.Repositories;
using si730ebu202123548.API.Observability.Domain.Services;
using si730ebu202123548.API.shared.Domain.Repositories;

namespace si730ebu202123548.API.Observability.Application.Internal.CommandServices;

public class ThingStateCommandService(IThingStateRepository thingStateRepository, IUnitOfWork unitOfWork)
            :IThingStateCommandService
{
    public async Task<ThingState?> HandleCommand(CreateThingStateCommand command)
    {
        var thingState = new ThingState(command);
        await thingStateRepository.AddAsync(thingState);
        await unitOfWork.CompleteAsync();
        return thingState;
    }
}