using System;
using System.Collections.Generic;

namespace ReTurnoWeb.Models;

public partial class Administracion
{
    public int Id { get; set; }

    public int? SucursalId { get; set; }

    public int? UsuarioId { get; set; }

    public int? EstadoBaja { get; set; }

    public virtual Sucursal? Sucursal { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
