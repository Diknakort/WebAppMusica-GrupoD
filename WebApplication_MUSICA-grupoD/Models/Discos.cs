using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_MUSICA_grupoD.Models;

public partial class Discos
{
    public int Id { get; set; }

    public string? Nombre { get; set; }
    [DataType(DataType.Date)]
    public DateOnly? Fecha { get; set; }
    [DisplayName("Genero musical")]
    public int? GeneroID { get; set; }
    [DisplayName("Grupo")]
    public int? GruposId { get; set; }

    public virtual ICollection<Canciones> Canciones { get; set; } = new List<Canciones>();

    public virtual Generos? Genero { get; set; }

    public virtual Grupos? Grupos { get; set; }
}
