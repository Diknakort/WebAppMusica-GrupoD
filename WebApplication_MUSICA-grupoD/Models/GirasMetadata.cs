using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication_MUSICA_grupoD.Models
{
    [ModelMetadataType(typeof(GirasMetadata))]
    public partial class Giras { }
    public class GirasMetadata
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateOnly? Fecha_Inicio { get; set; }
        [DisplayName("Nombre de Gira")]
        public string? Nombre { get; set; }
        [DataType(DataType.Date)]
        public DateOnly? Fecha_Final { get; set; }
    }
}
