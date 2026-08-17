using Clientes.BusinessLogic.Common;
using Clientes.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.BusinessLogic.Interfaces
{
    public interface IClienteQueryService
    {
        Task<DataCollection<ClienteDto>> GetAllAsync(int pagina,
    int tamanioPagina,
    string? busqueda = null,
    bool? activo = null,
    string? ordenarPor = null,
    string? direccion = null);

        Task<ClienteDto> GetAsync(int id);
    }
}
