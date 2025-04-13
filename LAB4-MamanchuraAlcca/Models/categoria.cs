using System;
using System.Collections.Generic;

namespace LAB4_MamanchuraAlcca.Models;

public partial class categoria
{
    public int CategoriaID { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<producto> productos { get; set; } = new List<producto>();
}
