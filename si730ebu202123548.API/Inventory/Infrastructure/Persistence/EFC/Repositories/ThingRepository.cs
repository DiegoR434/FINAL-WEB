using Microsoft.EntityFrameworkCore;
using si730ebu202123548.API.Inventory.Domain.Model.Aggregates;
using si730ebu202123548.API.Inventory.Domain.Repositories;
using si730ebu202123548.API.shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu202123548.API.shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebu202123548.API.Inventory.Infrastructure.Repositories;

public class ThingRepository : BaseRepository<Thing>, IThingRepository
{
    public ThingRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Thing?> FindByIdAsync(int id)
    {
        return await Context.Set<Thing>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Thing?> FindBySerialNumberAsync(int serialNumber)
    {
        return await Context.Set<Thing>().FirstOrDefaultAsync(p => p.serialNumber == serialNumber);
    }
}