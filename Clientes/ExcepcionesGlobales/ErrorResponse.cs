using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Service.ExcepcionesGlobales
{
    public class ErrorResponse
    {
        [Required]
        public string Titulo { get; set; }
        
        [Required]
        public int CodigoEstado { get; set; }
        
        [Required]
        public string Mensaje { get; set; }
    }
}
