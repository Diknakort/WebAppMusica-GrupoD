using System;
using System.Collections.Generic;

namespace WebAppMUSICA.Models;

public partial class Grupos
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? FechaCreaccion { get; set; }

    public int? ManagersID { get; set; }

    public virtual ICollection<Colaboraciones> Colaboraciones { get; set; } = new List<Colaboraciones>();

    public virtual ICollection<Conciertos> Conciertos { get; set; } = new List<Conciertos>();

    public virtual ICollection<Discos> Discos { get; set; } = new List<Discos>();

    public virtual Managers? Managers { get; set; }
}
