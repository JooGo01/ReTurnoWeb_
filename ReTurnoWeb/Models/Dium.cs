using System;
using System.Collections.Generic;

namespace ReTurnoWeb.Models;

public partial class Dium
{
    public int Id { get; set; }

    public string NombreDia { get; set; } = null!;

    public virtual ICollection<Atencion> Atencions { get; set; } = new List<Atencion>();
}
