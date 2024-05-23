using System;
using System.Collections.Generic;

namespace WebApplication_MUSICA_grupoD.Models;

public partial class Conciertos
{
    public int Id { get; set; }

    public decimal? Precio { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? Ciudad { get; set; }

    public int? GruposID { get; set; }

    public int? GirasID { get; set; }

    public virtual Giras? Giras { get; set; }

    public virtual Grupos? Grupos { get; set; }
}
