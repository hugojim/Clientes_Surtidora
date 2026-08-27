using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.BusinessLogic.Productos.ProductoCommands
{
    public class ProductoDeleteCommand :INotification
    {
        public int ProductoId { get; set; }
    }
}
