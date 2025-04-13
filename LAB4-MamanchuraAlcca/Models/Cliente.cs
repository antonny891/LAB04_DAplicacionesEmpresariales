using System;
using System.Collections.Generic;

namespace LAB4_MamanchuraAlcca.Models;

public partial class cliente
{
    public int ClienteID { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Ordene> ordenes { get; set; } = new List<Ordene>();
}
