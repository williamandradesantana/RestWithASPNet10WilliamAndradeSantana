using RestWithASPNet10WilliamAndradeSantana.Services;
using RestWithASPNet10WilliamAndradeSantana.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<MathService>();
builder.Services.AddSingleton<MathUtils>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
