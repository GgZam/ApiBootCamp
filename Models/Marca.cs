using System;
using System.Collections.Generic;

namespace EjemploEntity.Models;

public partial class Marca
{
    public double MarcaId { get; set; }

    public string? MarcaNombre { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
