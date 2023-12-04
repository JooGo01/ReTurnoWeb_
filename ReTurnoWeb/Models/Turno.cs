using System;
using System.Collections.Generic;

namespace ReTurnoWeb.Models;

public partial class Turno
{
    public int Id { get; set; }

    public int? SucursalId { get; set; }

    public int? UsuarioId { get; set; }

    public DateTime? FechaIni { get; set; }

    public DateTime? FechaFin { get; set; }

    public int? EstadoBaja { get; set; }

    public int? ServicioId { get; set; }

    public virtual Servicio? Servicio { get; set; }

    public virtual Sucursal? Sucursal { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
