using System;
using System.Collections.Generic;

namespace WebAppMUSICA.Models;

public partial class Giras
{
    public int Id { get; set; }

    public DateOnly? Fecha_Inicio { get; set; }

    public DateOnly? Fecha_Final { get; set; }
    public string? Nombre {  get; set; }

    public virtual ICollection<Conciertos> Conciertos { get; set; } = new List<Conciertos>();
}
