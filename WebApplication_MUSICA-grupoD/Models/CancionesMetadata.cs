using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_MUSICA_grupoD.Models;
[ModelMetadataType(typeof(CancionesMetadata))]
public partial class Canciones { }
public partial class CancionesMetadata
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public TimeOnly? Duracion { get; set; }

    public int? DiscosID { get; set; }

}
