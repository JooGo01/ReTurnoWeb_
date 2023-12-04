using System;
using System.Collections.Generic;

namespace ReTurnoWeb.Models;

public partial class Servicio
{
    public int Id { get; set; }

    public string? NombreServicio { get; set; }

    public virtual ICollection<SucursalServicio> SucursalServicios { get; set; } = new List<SucursalServicio>();

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
