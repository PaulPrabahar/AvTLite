using BuildingBlocks.Behaviours;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;
var cs = builder.Configuration.GetConnectionString("Database")!;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(LogginBehaviour<,>));
});

builder.Services.AddDbContext<LoginDbContext>(opt =>
{
    opt.UseNpgsql(cs, npg =>
    {
        npg.EnableRetryOnFailure();  // transient faults
    });
});

builder.Services.AddCarter();

var app = builder.Build();

app.MapCarter();

app.Run();
