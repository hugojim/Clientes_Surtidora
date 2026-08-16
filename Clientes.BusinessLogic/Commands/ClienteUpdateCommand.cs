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

        public string ApellidoPaterno { get; set; } = null!;

        public string? ApellidoMaterno { get; set; }

        public string CorreoElectronico { get; set; } = null!;

        public string? Telefono { get; set; }

        public DateOnly? FechaNacimiento { get; set; }

        public string? Direccion { get; set; }

        public string Ciudad { get; set; } = null!;

        public string? CodigoPostal { get; set; }

        public bool Activo { get; set; }
    }
}
