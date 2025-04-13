using System;
using System.Collections.Generic;

namespace LAB4_MamanchuraAlcca.Models;

public partial class detallesorden
{
    public int DetalleID { get; set; }

    public int? OrdenID { get; set; }

    public int? ProductoID { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public virtual Ordene? Orden { get; set; }

    public virtual producto? Producto { get; set; }
}
