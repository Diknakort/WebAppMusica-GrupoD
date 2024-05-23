using System;
using System.Collections.Generic;

namespace WebAppMUSICA.Models;

public partial class Managers
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? Fecha_Nacimiento { get; set; }

    public virtual ICollection<Grupos> Grupos { get; set; } = new List<Grupos>();
}
