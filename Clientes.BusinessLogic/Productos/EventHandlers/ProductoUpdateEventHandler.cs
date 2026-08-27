using Clientes.BusinessLogic.Commands;
using Clientes.BusinessLogic.Common;
using Clientes.BusinessLogic.Productos.ProductoCommands;
using Clientes.DataAccess.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.BusinessLogic.Productos.EventHandlers
{
    public class ProductoUpdateEventHandler : INotificationHandler<ProductoUpdateCommand>

    {
        private readonly ClientesdbContext _context;

        public ProductoUpdateEventHandler(ClientesdbContext context)
        {
            _context = context;
        }

        public async Task Handle(ProductoUpdateCommand productoCommand, CancellationToken cancellationToken)
        {
            var productoActualizar = await _context.Productos
                .AsNoTracking()
                .Where(x => x.Id == productoCommand.ProductoId)
                .FirstOrDefaultAsync();

            if (productoActualizar == null)
            {
                throw new ClienteNoEncontradoException("No se encontro el cliente a actualizar");
            }


            productoActualizar.Nombre = productoCommand.Nombre;
            productoActualizar.Precio= productoCommand.Precio ;
            productoActualizar.Cantidad= productoCommand.Cantidad;
         

            _context.Productos.Update(productoActualizar);
            await _context.SaveChangesAsync();

        }
    }
}
