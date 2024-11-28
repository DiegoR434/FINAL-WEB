using Microsoft.EntityFrameworkCore;
using si730ebu202123548.API.Observability.Domain.Model.Aggregates;
using si730ebu202123548.API.Observability.Domain.Repositories;
using si730ebu202123548.API.shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu202123548.API.shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebu202123548.API.Observability.Infrastructure.Persistence.EFC.Repositories;

public class ThingStateRepository : BaseRepository<ThingState>, IThingStateRepository
{
    public ThingStateRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<ThingState?> FindByIdAsync(int id)
    {
        return await Context.Set<ThingState>().FirstOrDefaultAsync(t => t.Id == id);
    }
}