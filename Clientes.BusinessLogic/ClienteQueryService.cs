
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
        public async Task<DataCollection<ClienteDto>> GetAllAsync(int pagina,
    int tamanioPagina,
    string? busqueda = null,
    bool? activo = null,
    string? ordenarPor = null,
    string? direccion = null)
        {
            var query = _clientesDbContext.Clientes
        .AsNoTracking()
        .AsQueryable();

            // Búsqueda
            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                var texto = busqueda.Trim();

                query = query.Where(x =>
                    x.Nombre.Contains(texto) ||
                    x.ApellidoPaterno.Contains(texto) ||
                    x.ApellidoMaterno.Contains(texto) ||
                    x.CorreoElectronico.Contains(texto) ||
                    x.Telefono.Contains(texto));
            }

            // Filtro por estado
            if (activo.HasValue)
            {
                query = query.Where(x =>
                    x.Activo == activo.Value);
            }

            // Ordenamiento
            query = ordenarPor?.ToLower() switch
            {
                "nombre" =>
                    direccion?.ToLower() == "desc"
                        ? query.OrderByDescending(x => x.Nombre)
                        : query.OrderBy(x => x.Nombre),

                "correo" =>
                    direccion?.ToLower() == "desc"
                        ? query.OrderByDescending(x => x.CorreoElectronico)
                        : query.OrderBy(x => x.CorreoElectronico),

                "telefono" =>
                    direccion?.ToLower() == "desc"
                        ? query.OrderByDescending(x => x.Telefono)
                        : query.OrderBy(x => x.Telefono),

                "activo" =>
                    direccion?.ToLower() == "desc"
                        ? query.OrderByDescending(x => x.Activo)
                        : query.OrderBy(x => x.Activo),

                _ => query.OrderBy(x => x.ClienteId)
            };

            // Proyección
            var queryDto = query.Select(x => new ClienteDto
            {
                ClienteId = x.ClienteId,
                Nombre = x.Nombre,
                ApellidoPaterno = x.ApellidoPaterno,
                ApellidoMaterno = x.ApellidoMaterno,
                CorreoElectronico = x.CorreoElectronico,
                Telefono = x.Telefono,
                Activo = x.Activo
            });

            // Paginación
            return await queryDto.GetPagedAsync(
                pagina,
                tamanioPagina);

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
