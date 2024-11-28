using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using si730ebu202123548.API.Inventory.Application.Internal.CommandServices;
using si730ebu202123548.API.Inventory.Application.Internal.QueryServices;
using si730ebu202123548.API.Inventory.Domain.Repositories;
using si730ebu202123548.API.Inventory.Domain.Services;
using si730ebu202123548.API.Inventory.Infrastructure.Repositories;
using si730ebu202123548.API.Observability.Application.Internal.CommandServices;
using si730ebu202123548.API.Observability.Application.Internal.QueryServices;
using si730ebu202123548.API.Observability.Domain.Repositories;
using si730ebu202123548.API.Observability.Domain.Services;
using si730ebu202123548.API.Observability.Infrastructure.Persistence.EFC.Repositories;
using si730ebu202123548.API.shared.Domain.Repositories;
using si730ebu202123548.API.shared.Infrastructure.Interfaces.ASP.Configuration;
using si730ebu202123548.API.shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu202123548.API.shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Kebab Case Route Naming Convention
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Kebab Case Route Naming Convention
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Verify Database Connection String
if (connectionString is null)
    // Stop the application if the connection string is not set.
    throw new Exception("Database connection string is not set.");


// Configure Database Context and Logging Levels
if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableDetailedErrors();
        });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Patients Endpoint API",
            Version = "v1",
            Description = "HealthTrack. API",
            TermsOfService = new Uri("https://acme-learning.com/tos"),
            Contact = new OpenApiContact
            {
                Name = "ACME Studios",
                Email = "contact@acme.com"
            },
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
            }
        });
    
    options.EnableAnnotations();
});

// Dependency Injection

// Shared Bounded Context
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Inventory Bounded Context

builder.Services.AddScoped<IThingRepository, ThingRepository>();
builder.Services.AddScoped<IThingCommandService, ThingCommandService>();
builder.Services.AddScoped<IThingQueryService, ThingQueryService>();

// Observability Bounded Context

builder.Services.AddScoped<IThingStateRepository, ThingStateRepository>();
builder.Services.AddScoped<IThingStateCommandService, ThingStateCommandService>();
builder.Services.AddScoped<IThingStateQueryService, ThingStateQueryService>();


var app = builder.Build();

// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add Authorization Middleware to Pipeline
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
