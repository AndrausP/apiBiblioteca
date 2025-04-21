using Biblioteca.DATA;
using Biblioteca.Services; // Adicionando a diretiva using para o namespace correto onde ILivroService e LivroService estão definidos
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServicesLivros, ServicesLivros>();


// Configuração do db via entity
builder.Services.AddDbContext<DataFile>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("stringConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("stringConnection"))));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataFile>();
    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
