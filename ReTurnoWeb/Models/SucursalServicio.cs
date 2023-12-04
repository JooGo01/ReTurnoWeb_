using System;
using System.Collections.Generic;

namespace ReTurnoWeb.Models;

public partial class SucursalServicio
{
    public int Id { get; set; }

    public int? SucursalId { get; set; }

    public int? ServicioId { get; set; }

    public int TiempoServicio { get; set; }

    public int? EstadoBaja { get; set; }

    public virtual ICollection<Atencion> Atencions { get; set; } = new List<Atencion>();

    public virtual Servicio? Servicio { get; set; }

    public virtual Sucursal? Sucursal { get; set; }
}
