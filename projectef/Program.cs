using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyjectef;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TareasContex>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContex>(builder.Configuration.GetConnectionString("cnTareas"));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapGet("/dbconexion", ([FromServices] TareasContex dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria:" + dbContext.Database.IsInMemory());
});

app.Run();
