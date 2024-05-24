using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_MUSICA_grupoD.Models;

public partial class Generos
{
    public int Id { get; set; }
    [Required(ErrorMessage ="el nombre del genero es requerido")]
    [DisplayName("Tipo/Genero")]
    public string? Nombre { get; set; }

    public virtual ICollection<Discos> Discos { get; set; } = new List<Discos>();
}
