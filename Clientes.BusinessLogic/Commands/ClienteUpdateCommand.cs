using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.BusinessLogic.Commands
{
    public class ClienteUpdateCommand : INotification
    {
        public int ClienteId{ get; set; }
        public string Nombre { get; set; } = null!;

        public string ApellidoPaterno { get; set; } = string.Empty;

        public string ApellidoMaterno { get; set; } = string.Empty;

        public string CorreoElectronico { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public DateTime FechaNacimiento { get; set; }

        public string Direccion { get; set; } = string.Empty;

        public string Ciudad { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;

        public bool Activo { get; set; }
    }
}
