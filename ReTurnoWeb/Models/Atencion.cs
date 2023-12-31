﻿using System;
using System.Collections.Generic;

namespace ReTurnoWeb.Models;

public partial class Atencion
{
    public int Id { get; set; }

    public int? DiaId { get; set; }

    public int? SucursalServicioId { get; set; }

    public int HoraApertura { get; set; }

    public int HoraCierre { get; set; }

    public int PersonalServicio { get; set; }

    public int? EstadoBaja { get; set; }

    public virtual Dium? Dia { get; set; }

    public virtual SucursalServicio? SucursalServicio { get; set; }
}
