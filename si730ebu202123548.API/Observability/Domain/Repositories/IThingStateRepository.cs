using si730ebu202123548.API.Observability.Domain.Model.Aggregates;
using si730ebu202123548.API.shared.Domain.Repositories;

namespace si730ebu202123548.API.Observability.Domain.Repositories;

public interface IThingStateRepository: IBaseRepository<ThingState>
{
    Task<ThingState?> FindByIdAsync(int id);
}