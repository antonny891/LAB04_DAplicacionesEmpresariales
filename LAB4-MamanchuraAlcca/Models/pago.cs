using System;
using System.Collections.Generic;

namespace LAB4_MamanchuraAlcca.Models;

public partial class pago
{
    public int PagoID { get; set; }

    public int? OrdenID { get; set; }

    public decimal Monto { get; set; }

    public DateTime? FechaPago { get; set; }

    public string? MetodoPago { get; set; }

    public virtual Ordene? Orden { get; set; }
}
