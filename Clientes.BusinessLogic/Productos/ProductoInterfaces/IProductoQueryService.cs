using Clientes.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.BusinessLogic.Productos.ProductoInterfaces
{
    public interface IProductoQueryService
    {
      public  Task<List<ProductoDTO>> ObtenerProductos();

      public  Task<ProductoDTO> ObtenerProducto(int id);

    }
}
