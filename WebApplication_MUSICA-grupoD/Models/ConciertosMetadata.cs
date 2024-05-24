using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_MUSICA_grupoD.Models;
[ModelMetadataType(typeof(ConciertosMetadata))]
public partial class Conciertos { }
public partial class ConciertosMetadata
{
    public int Id { get; set; }
    [DataType(DataType.Currency)]
    public decimal? Precio { get; set; }
    [DataType(DataType.Date)]
    public DateTime? FechaHora { get; set; }

    public string? Ciudad { get; set; }

    public int? GruposID { get; set; }

    public int? GirasID { get; set; }

}
