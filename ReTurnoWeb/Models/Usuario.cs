using System;
using System.Collections.Generic;

namespace ReTurnoWeb.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Dni { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Contrasenia { get; set; }

    public string? TipoUsuario { get; set; }

    public int? DireccionId { get; set; }

    public int? EstadoBaja { get; set; }

    public virtual ICollection<Administracion> Administracions { get; set; } = new List<Administracion>();

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Direccion? Direccion { get; set; }

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
