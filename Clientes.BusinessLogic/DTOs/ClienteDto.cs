using System.ComponentModel.DataAnnotations;


namespace Clientes.BusinessLogic.DTOs
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string ApellidoPaterno { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ApellidoMaterno { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Correo electronico invalido")]
        [MaxLength(200)]
        public string CorreoElectronico { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Telefono { get; set; } = string.Empty;

        public DateTime FechaNacimiento { get; set; }

        [MaxLength(250)]
        public string Direccion { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Ciudad { get; set; } = null!;
        [MaxLength(10)]
        public string? CodigoPostal { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaRegistro { get; set; }

        public DateTime? FechaModificacion { get; set; } 

        public string NombreCompleto =>
      $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}".Trim();


    }
}
