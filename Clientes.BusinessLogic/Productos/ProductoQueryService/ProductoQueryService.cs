
using Clientes.BusinessLogic.Common;
using Clientes.BusinessLogic.DTOs;
using Clientes.BusinessLogic.Productos.ProductoInterfaces;
using Clientes.DataAccess.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Clientes.BusinessLogic.Productos.ProductoQueryService
{
    public class ProductoQueryService : IProductoQueryService
    {

        private readonly ClientesdbContext _clientesDbContext;

        public ProductoQueryService(ClientesdbContext clientesDbContext)
        {
            _clientesDbContext = clientesDbContext;
        }

        public async Task<ProductoDTO> ObtenerProducto(int id)
        {
            var product = await _clientesDbContext.Productos
         .AsNoTracking()
         .Where(x => x.Id == id)
          .Select(x => new ProductoDTO
          {
              ProductoId = x.Id,
              Nombre = x.Nombre,
              Cantidad = x.Cantidad,
              Precio = (decimal)x.Precio

          })
         .FirstOrDefaultAsync();

            if (product == null)
            {
                throw new KeyNotFoundException ("No se encontro el producto");
            }
            return product;

        }

        public async Task<List<ProductoDTO>> ObtenerProductos()
        {

            var query = _clientesDbContext.Productos
            .AsNoTracking()
            .OrderByDescending(x => x.Id)
            .Select(x => new ProductoDTO
            {
                ProductoId = x.Id,
                Nombre = x.Nombre,
                Cantidad = x.Cantidad,
                Precio = (decimal)x.Precio

            }).ToListAsync();

            return await query;

        }
    }
}
