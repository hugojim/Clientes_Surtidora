using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.BusinessLogic.Productos.ProductoCommands
{
    public class ProductoUpdateCommand : INotification
    {
        public int ProductoId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public int Cantidad { get; set; } = 0;


        [Required]
        public int Precio { get; set; } = 0;
    }
}
