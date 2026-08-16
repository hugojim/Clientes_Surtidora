using Clientes.BusinessLogic.Commands;
using Clientes.BusinessLogic.Common;
using Clientes.BusinessLogic.DTOs;
using Clientes.BusinessLogic.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Clientes.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteQueryService _clienteQueryService;
        private readonly IMediator _mediator;
        public ClientesController(IClienteQueryService clienteQueryService, IMediator mediator)
        {
            _clienteQueryService = clienteQueryService;
            _mediator = mediator;
        }

        //Clientes
        [HttpGet]
        public async Task<IActionResult> GetAll(int pagina = 1, int tamanioPagina = 10)
        {
            var clientes = await _clienteQueryService.GetAllAsync(pagina, tamanioPagina);
            return Ok(clientes);
        }

        //Clientes/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == 0 || id is null)
            {
                return BadRequest("Cliente ID invalido");
            }

            return Ok(await _clienteQueryService.GetAsync(id.Value));
        }

        //Clientes
        [HttpPost]
        public async Task<IActionResult> Create(ClienteCreateCommand clienteCommand)
        {
            await _mediator.Publish(clienteCommand);
            return Created();
        }

        //Clientes/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int? id, [FromBody] ClienteDto clienteDto)
        {

            if (id == 0 || id is null)
            {
                return BadRequest("Cliente Id Invalido");
            }
            ClienteUpdateCommand clienteUpdateCommand = clienteDto.MapTo<ClienteUpdateCommand>();
            clienteUpdateCommand.ClienteId = id.Value;
            await _mediator.Publish(clienteUpdateCommand);

            return Ok();
        }


        //Clientes/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == 0 || id is null)
            {
                return BadRequest("Cliente Id Invalido");
            }
            await _mediator.Publish(new ClienteDeleteCommand { ClienteId = id.Value });
            return NoContent();
        }
    }
}
