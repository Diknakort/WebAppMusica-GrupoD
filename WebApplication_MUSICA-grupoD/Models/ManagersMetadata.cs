using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_MUSICA_grupoD.Models;

[ModelMetadataType(typeof(ManagersMetadata))]
public partial class Managers { }
public partial class ManagersMetadata
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? Fecha_Nacimiento { get; set; }

}
