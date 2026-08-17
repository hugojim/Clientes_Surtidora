using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.BusinessLogic.Commands
{
    public class ClienteCreateCommand :INotification
    {
        [Required]
        [MaxLength(100) ]
        public string Nombre { get; set; } = null!;
        
        [Required]
        [MaxLength(100)]
        public string ApellidoPaterno { get; set; } = null!;
        
        [MaxLength(100)]
        public string? ApellidoMaterno { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Correo electronico invalido")]
        [MaxLength(200)]
        public string CorreoElectronico { get; set; } = null!;
        [Phone]
        [MaxLength(20)]
        public string? Telefono { get; set; } = string.Empty;

        public DateOnly? FechaNacimiento { get; set; } = DateOnly.MinValue;
        [MaxLength(250)]
        public string? Direccion { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Ciudad { get; set; } = string.Empty;
        [MaxLength(10)]
        public string? CodigoPostal { get; set; } = string.Empty;

    }
}
