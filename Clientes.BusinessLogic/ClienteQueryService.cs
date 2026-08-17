
using Clientes.BusinessLogic.Common;
using Clientes.BusinessLogic.DTOs;
using Clientes.BusinessLogic.Interfaces;
using Clientes.DataAccess;
using Clientes.DataAccess.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Clientes.BusinessLogic
{
    public class ClienteQueryService : IClienteQueryService
    {
        private readonly ClientesDbContext _clientesDbContext;

        public ClienteQueryService(ClientesDbContext clientesDbContext)
        {
            _clientesDbContext = clientesDbContext;
        }
        public async Task<DataCollection<ClienteDto>> GetAllAsync(int page, int take)
        {
            var collection = await _clientesDbContext.Clientes
                .AsNoTracking()
                .Where(x => x.Activo.Equals(true))
                .OrderByDescending(x => x.ClienteId).GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ClienteDto>>();

        }

        public async Task<ClienteDto> GetAsync(int id)
        {
            var clienteRetornar = await _clientesDbContext.Clientes
                .AsNoTracking()
                .Where(x => x.ClienteId == id)
                .FirstOrDefaultAsync();

            if (clienteRetornar == null)
            {
                throw new MissingFieldException("No se encontro el cliente a retrnar");
            }
            return (clienteRetornar.MapTo<ClienteDto>());
        }
    }
}
