using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_MUSICA_grupoD.Models
{
    [ModelMetadataType(typeof(GenerosMetadata))]
    public partial class Generos { }
    public class GenerosMetadata
    {
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
    }
}
