﻿using System;
using System.Collections.Generic;

namespace SGPI.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public int IdUsuario { get; set; }

    public double ValorPago { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
