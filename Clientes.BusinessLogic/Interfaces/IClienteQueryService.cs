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
        Task<DataCollection<ClienteDto>> GetAllAsync(int page, int take);

        Task<ClienteDto> GetAsync(int id);
    }
}
