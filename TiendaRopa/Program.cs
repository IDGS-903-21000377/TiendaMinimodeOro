using Microsoft.EntityFrameworkCore;
using TiendaRopa.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("nuevaPolitica", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var connectionString = builder.Configuration.GetConnectionString("StringSql");

builder.Services.AddDbContext<Bdproductos903Context>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build(); // Mover la declaración de 'app' antes de su uso

// Ejecutar SeedData
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Inicializar(services);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("nuevaPolitica"); // Activamos la política

app.UseAuthorization();

app.MapControllers();

app.Run();
