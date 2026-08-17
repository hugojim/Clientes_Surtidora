using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.BusinessLogic.Commands
{
    public class ClienteDeleteCommand :INotification
    {
        public int ClienteId { get; set; }
    }
}
    