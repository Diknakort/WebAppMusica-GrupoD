using System;
using System.Collections.Generic;

namespace WebApplication_MUSICA_grupoD.Models;

public partial class Canciones
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public TimeOnly? Duracion { get; set; }

    public int? DiscosID { get; set; }

    public virtual Discos? Discos { get; set; }
}
