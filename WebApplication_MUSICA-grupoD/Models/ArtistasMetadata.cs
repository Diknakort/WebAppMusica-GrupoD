using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace WebApplication_MUSICA_grupoD.Models;

[ModelMetadataType(typeof(ArtistasMetadata))]
public partial class Artistas { }
public partial class ArtistasMetadata
{
    public int Id { get; set; }
    [DisplayName("Nombre que le puso su madre")]
    public string? Nombre_Real { get; set; }
    [DisplayName("Como se le conoce")]
    public string? Nombre_Artistico { get; set; }
    [DisplayName("Fecha de nacimiento")]
    [DataType(DataType.Date)]
    public DateOnly? Fecha_Nacimiento { get; set; }
  
    
    public int? RolPrincipal { get; set; }
    
}
