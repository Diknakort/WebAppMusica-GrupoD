using System;
using System.Collections.Generic;

namespace WebAppMUSICA.Models;

public partial class Generos
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Discos> Discos { get; set; } = new List<Discos>();
}
