using System;
using System.Collections.Generic;

namespace EjemploEntity.Models;

public partial class Producto
{
    public double ProductoId { get; set; }

    public string? ProductoDescrip { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public decimal? Precio { get; set; }

    public double? CategId { get; set; }

    public double? MarcaId { get; set; }

    public double? ModeloId { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
