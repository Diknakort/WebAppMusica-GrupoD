using System;
using System.Collections.Generic;

namespace WebApplication_MUSICA_grupoD.Models;

public partial class Artistas
{
    public int Id { get; set; }

    public string? Nombre_Real { get; set; }

    public string? Nombre_Artistico { get; set; }

    public DateOnly? Fecha_Nacimiento { get; set; }

    public int? RolPrincipal { get; set; }

    public virtual ICollection<Colaboraciones> Colaboraciones { get; set; } = new List<Colaboraciones>();

    public virtual Roles? RolPrincipalNavigation { get; set; }
}
