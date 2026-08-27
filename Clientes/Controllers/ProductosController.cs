using Clientes.BusinessLogic.Commands;
using Clientes.BusinessLogic.Common;
using Clientes.BusinessLogic.DTOs;
using Clientes.BusinessLogic.Productos.ProductoCommands;
using Clientes.BusinessLogic.Productos.ProductoInterfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Clientes.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoQueryService _productoQueryService;
        private readonly IMediator _mediator;


        public ProductosController(
            IProductoQueryService productoQueryService,
        IMediator mediator)
        {
            _mediator = mediator;
            _productoQueryService = productoQueryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoDTO>>> ObtenerProductos()
        {
            return Ok(await _productoQueryService.ObtenerProductos());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProductoDTO>>> ObtenerProducto(int id)
        {
            return Ok(await _productoQueryService.ObtenerProducto(id));
        }

        [HttpPost]
        public async Task<IActionResult> CrearProducto(ProductoCreateCommand productoCreateCommand)
        {
            await _mediator.Publish(productoCreateCommand);
            return Created();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProducto(int? id, [FromBody] ProductoDTO productoDTO)
        {
            if (id == 0 || id is null)
            {
                throw new InvalidDataException("Producto Id Invalido");
            }
            ProductoUpdateCommand productoUpdateCommand = productoDTO.MapTo<ProductoUpdateCommand>();
            productoUpdateCommand.ProductoId = (int)id;
            await _mediator.Publish(productoUpdateCommand);

            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarProducto(int? id)
        {
            if (id == 0 || id is null)
            {
                throw new InvalidDataException("producto Id Invalido");
            }
            await _mediator.Publish(new ProductoDeleteCommand { ProductoId = id.Value });
            return NoContent();

        }
    }
}
