using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si730ebu202123548.API.Inventory.Domain.Model.Aggregates;
using si730ebu202123548.API.Observability.Domain.Model.Aggregates;
using si730ebu202123548.API.shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace si730ebu202123548.API.shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Thing>().ToTable("Things");
        builder.Entity<Thing>().HasKey(p => p.Id);
        builder.Entity<Thing>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Thing>().Property(p=>p.serialNumber).IsRequired();
        builder.Entity<Thing>().Property(p => p.model).IsRequired();
        builder.Entity<Thing>().Property(p => p.operationMode).IsRequired();
        builder.Entity<Thing>().Property(p => p.maximumTemperatureThreshold).IsRequired();
        builder.Entity<Thing>().Property(p=> p.minimumHumidityThreshold).IsRequired();
        
        builder.Entity<ThingState>().ToTable("ThingStates");
        builder.Entity<ThingState>().HasKey(p => p.Id);
        builder.Entity<ThingState>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ThingState>().Property(p=> p.thingSerialNumber).IsRequired();
        builder.Entity<ThingState>().Property(p=> p.currentOperationMode).IsRequired();
        builder.Entity<ThingState>().Property(p=> p.currentTemperature).IsRequired();
        builder.Entity<ThingState>().Property(p=> p.currentHumidity).IsRequired();
        builder.Entity<ThingState>().Property(p=> p.collectedAt).IsRequired();

        
        builder.UseSnakeCaseNamingConvention();
    }
}
