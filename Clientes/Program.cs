using Clientes.BusinessLogic;
using Clientes.BusinessLogic.EvenHandlers;
using Clientes.BusinessLogic.Interfaces;
using Clientes.DataAccess.Entidades;
using Clientes.Service.ExcepcionesGlobales;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ClientesDbContext>(opts =>
opts.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));  
builder.Services.AddScoped<IClienteQueryService, ClienteQueryService>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ClienteCreateEventHandler).GetTypeInfo().Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ClienteDeleteEventHandler).GetTypeInfo().Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ClienteUpdateEventHandler).GetTypeInfo().Assembly));

var origenesPermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos")!.Split(",");


builder.Services.AddCors(options =>
{
    options.AddPolicy("Angular", policy =>
    {
        policy
            .WithOrigins(origenesPermitidos)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();
app.UseExceptionHandler();

app.UseHttpsRedirection();
app.UseCors("Angular");

app.UseAuthorization();

app.MapControllers();


app.Run();
