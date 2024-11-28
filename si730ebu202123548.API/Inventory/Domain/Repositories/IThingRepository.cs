using si730ebu202123548.API.Inventory.Domain.Model.Aggregates;
using si730ebu202123548.API.shared.Domain.Repositories;

namespace si730ebu202123548.API.Inventory.Domain.Repositories;

public interface IThingRepository:IBaseRepository<Thing>
{
    Task<Thing?> FindByIdAsync(int id);
    Task<Thing?> FindBySerialNumberAsync(int serialNumber);
}