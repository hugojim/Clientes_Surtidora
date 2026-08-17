using Clientes.BusinessLogic.Commands;
using Clientes.BusinessLogic.Common;
using Clientes.DataAccess;
using Clientes.DataAccess.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Clientes.BusinessLogic.EvenHandlers
{
    public class ClienteCreateEventHandler :INotificationHandler<ClienteCreateCommand>
    {
        private readonly ClientesDbContext _context;


        public ClienteCreateEventHandler(ClientesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ClienteCreateCommand clienteCommand, CancellationToken cancellationToken)
        {
            var correoDuplicado = await _context.Clientes
                 .AsNoTracking().
                  SingleOrDefaultAsync(x => x.CorreoElectronico == clienteCommand.CorreoElectronico);
            if (correoDuplicado != null)
            {
                throw new CorreoDuplicadoException("Correo Duplicado"); // 409
            }
           

            await _context.Clientes.AddAsync(new Cliente
            {
                Nombre = clienteCommand.Nombre,
                ApellidoPaterno = clienteCommand.ApellidoPaterno,
                ApellidoMaterno = clienteCommand.ApellidoMaterno,
                CorreoElectronico = clienteCommand.CorreoElectronico,
                Telefono = clienteCommand.Telefono,
                FechaNacimiento = DateOnly.FromDateTime(clienteCommand.FechaNacimiento),
                Direccion = clienteCommand.Direccion,
                Ciudad = clienteCommand.Ciudad,
                CodigoPostal = clienteCommand.CodigoPostal,
                Activo = true
                

            });

            await _context.SaveChangesAsync();
        }
    }
}
