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

builder.Services.AddCors(options =>
{
    options.AddPolicy("Publica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

//if (app.Environment.IsDevelopment())
//{
//    app.useSwagger();

//}

app.UseAuthorization();

app.MapControllers();


app.Run();
