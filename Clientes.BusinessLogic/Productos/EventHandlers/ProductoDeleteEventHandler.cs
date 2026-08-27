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
    public class ProductoDeleteEventHandler : INotificationHandler<ProductoDeleteCommand>
    {
        private readonly ClientesdbContext _context;
        public ProductoDeleteEventHandler(ClientesdbContext context)
        {
            _context = context;
        }

        public async Task Handle(ProductoDeleteCommand productoCommand, CancellationToken cancellationToken)
        {
            var productoEliminar = await _context.Productos
                 .AsNoTracking()
                .Where(x => x.Id == productoCommand.ProductoId)
                .FirstOrDefaultAsync();

            if (productoEliminar == null)
            {
                throw new ClienteNoEncontradoException("No se encontro el producto a eliminar");
            }

            //clienteEliminar.Activo = false;
            //clienteEliminar.FechaModificacion = DateTime.Now;

            _context.Productos.Update(productoEliminar);
            await _context.SaveChangesAsync();
        }


    }
}
