using si730ebu202123548.API.shared.Domain.Repositories;
using si730ebu202123548.API.shared.Infrastructure.Persistence.EFC.Configuration;

namespace si730ebu202123548.API.shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}