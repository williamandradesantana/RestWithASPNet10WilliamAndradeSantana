using RestWithASPNet10WilliamAndradeSantana.Configurations;
using RestWithASPNet10WilliamAndradeSantana.Services;
using RestWithASPNet10WilliamAndradeSantana.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddSerilogLogging();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddScoped<IPersonServices, PersonServicesImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
