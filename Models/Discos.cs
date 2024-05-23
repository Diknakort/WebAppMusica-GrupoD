using System;
using System.Collections.Generic;

namespace WebAppMUSICA.Models;

public partial class Discos
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? GeneroID { get; set; }

    public int? GruposId { get; set; }

    public virtual ICollection<Canciones> Canciones { get; set; } = new List<Canciones>();

    public virtual Generos? Genero { get; set; }

    public virtual Grupos? Grupos { get; set; }
}
