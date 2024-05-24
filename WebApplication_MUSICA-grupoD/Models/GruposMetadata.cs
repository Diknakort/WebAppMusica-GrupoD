using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_MUSICA_grupoD.Models;
[ModelMetadataType(typeof(GruposMetadata))]
public partial class Grupos { }
public partial class GruposMetadata
{
    public int Id { get; set; }

    public string? Nombre { get; set; }
    [DataType(DataType.Date)]
    public DateOnly? FechaCreaccion { get; set; }

    public int? ManagersID { get; set; }

}
