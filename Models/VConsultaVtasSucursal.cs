using System;
using System.Collections.Generic;

namespace EjemploEntity.Models;

public partial class VConsultaVtasSucursal
{
    public string? SucursalNombre { get; set; }

    public double? UnidadesVendidas { get; set; }

    public double? UsdVenta { get; set; }

    public int? Registros { get; set; }
}
