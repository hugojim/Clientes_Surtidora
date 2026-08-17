using Clientes.BusinessLogic;
using Clientes.BusinessLogic.Interfaces;
using Clientes.DataAccess.Entidades;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using Clientes.BusinessLogic.EvenHandlers;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ClientesDbContext>(opts =>
opts.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));  
builder.Services.AddScoped<IClienteQueryService, ClienteQueryService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ClienteCreateEventHandler).GetTypeInfo().Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ClienteDeleteEventHandler).GetTypeInfo().Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ClienteUpdateEventHandler).GetTypeInfo().Assembly));

var origenesPermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos")!.Split(",");

builder.Services.AddCors(options =>
{
    options.AddPolicy("Angular", policy =>
    {
        policy
            .WithOrigins("origenesPermitidos")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("Angular");

app.UseAuthorization();

app.MapControllers();


app.Run();
