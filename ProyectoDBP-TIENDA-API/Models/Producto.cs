using System;
using System.Collections.Generic;

namespace ProyectoDBP_TIENDA_API.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Detalle { get; set; }

    public decimal? Precio { get; set; }

    public int? Cantidad { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
