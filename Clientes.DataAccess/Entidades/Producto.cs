using System;
using System.Collections.Generic;

namespace Clientes.DataAccess.Entidades;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int Cantidad { get; set; }

    public decimal? Precio { get; set; }
}
