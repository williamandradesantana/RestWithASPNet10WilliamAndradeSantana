using RestWithASPNet10WilliamAndradeSantana.Configurations;
using RestWithASPNet10WilliamAndradeSantana.Repositories;
using RestWithASPNet10WilliamAndradeSantana.Repositories.Implementation;
using RestWithASPNet10WilliamAndradeSantana.Services;
using RestWithASPNet10WilliamAndradeSantana.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddSerilogLogging();

builder.Services.AddControllers();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);

builder.Services.AddScoped<IPersonServices, PersonServicesImplementation>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddScoped<IBookServices, BookServicesImplementation>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
