using Clientes.BusinessLogic.Commands;
using Clientes.BusinessLogic.Common;
using Clientes.BusinessLogic.Productos.ProductoCommands;
using Clientes.DataAccess.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.BusinessLogic.Productos.EventHandlers
{
    public class ProductoCreateEventHandler : INotificationHandler<ProductoCreateCommand>
    {
        private readonly ClientesdbContext _context;


        public ProductoCreateEventHandler(ClientesdbContext context)
        {
            _context = context;
        }

        public async Task Handle(ProductoCreateCommand productoCommand, CancellationToken cancellationToken)
        {
         


            await _context.Productos.AddAsync(new Producto
            {
                Nombre = productoCommand.Nombre,
                Cantidad = productoCommand.Cantidad,
                Precio= productoCommand.Precio
            });

            await _context.SaveChangesAsync();
        }
    }
}

