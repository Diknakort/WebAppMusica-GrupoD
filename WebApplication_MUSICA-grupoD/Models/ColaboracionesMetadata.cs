using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_MUSICA_grupoD.Models;
[ModelMetadataType(typeof(ColaboracionesMetadata))]
public partial class Colaboraciones { }
public partial class ColaboracionesMetadata
{
    public int Id { get; set; }

    public int? GruposID { get; set; }

    public int? ArtistasID { get; set; }


}
