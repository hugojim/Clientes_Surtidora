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
    public class ClienteDeleteEventHandler :INotificationHandler<ClienteDeleteCommand>
    {
        private readonly ClientesDbContext _context;
        public ClienteDeleteEventHandler(ClientesDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ClienteDeleteCommand clienteCommand, CancellationToken cancellationToken)
        {
            var clienteEliminar = await _context.Clientes
                 .AsNoTracking()
                .Where(x=> x.ClienteId ==  clienteCommand.ClienteId)
                .FirstOrDefaultAsync();

            if (clienteEliminar == null)
            {                
                throw new MissingFieldException("No se encontro el cliente a eliminar" );
            }

            clienteEliminar.Activo = false;
            clienteEliminar.FechaModificacion = DateTime.Now;

            _context.Update(clienteEliminar);
            await _context.SaveChangesAsync();
        }
    }
}
