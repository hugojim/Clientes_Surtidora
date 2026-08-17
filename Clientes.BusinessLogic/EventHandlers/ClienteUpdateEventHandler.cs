using Clientes.BusinessLogic.Commands;
using Clientes.DataAccess.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.BusinessLogic.EvenHandlers
{
    public class ClienteUpdateEventHandler : INotificationHandler<ClienteUpdateCommand>
    {
        private readonly ClientesDbContext _context;

        public ClienteUpdateEventHandler(ClientesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ClienteUpdateCommand clienteCommand, CancellationToken cancellationToken)
        {
            var clienteActualizar = await _context.Clientes
                .AsNoTracking()
                .Where(x => x.ClienteId == clienteCommand.ClienteId)
                .FirstOrDefaultAsync();

            if (clienteActualizar == null)
            {
                throw new MissingFieldException("No se encontro el cliente a actualizar");
            }

            var correoDuplicado = await _context.Clientes
              .AsNoTracking()
                .Where(x => x.CorreoElectronico == clienteCommand.CorreoElectronico
                            && x.ClienteId != clienteCommand.ClienteId).FirstOrDefaultAsync();

            if (correoDuplicado != null)
            {
                throw new DuplicateNameException("Correo Duplicado"); // 409
            }

            clienteActualizar.Nombre = clienteCommand.Nombre;
            clienteActualizar.ApellidoPaterno = clienteCommand.ApellidoPaterno;
            clienteActualizar.ApellidoMaterno = clienteCommand.ApellidoMaterno;
            clienteActualizar.CorreoElectronico = clienteCommand.CorreoElectronico;
            clienteActualizar.Telefono = clienteCommand.Telefono;
            clienteActualizar.FechaNacimiento = clienteCommand.FechaNacimiento;
            clienteActualizar.Direccion = clienteCommand.Direccion;
            clienteActualizar.Ciudad = clienteCommand.Ciudad;
            clienteActualizar.CodigoPostal = clienteCommand.CodigoPostal;
            clienteActualizar.Activo = clienteCommand.Activo;
            clienteActualizar.FechaModificacion = DateTime.Now;

            _context.Clientes.Update(clienteActualizar);
            await _context.SaveChangesAsync();

        }
    }
}
