using System;
using System.Collections.Generic;

namespace LAB4_MamanchuraAlcca.Models;

public partial class producto
{
    public int ProductoID { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public int? CategoriaID { get; set; }

    public virtual categoria? Categoria { get; set; }

    public virtual ICollection<detallesorden> detallesordens { get; set; } = new List<detallesorden>();
}
