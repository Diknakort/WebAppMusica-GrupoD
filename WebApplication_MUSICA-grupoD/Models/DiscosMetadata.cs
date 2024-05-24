using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication_MUSICA_grupoD.Models
{
    [ModelMetadataType(typeof(DiscosMetadata))]
    public partial class Discos { }
    public class DiscosMetadata
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }
        [DataType(DataType.Date)]
        public DateOnly? Fecha { get; set; }
        [DisplayName("Genero musical")]
        public int? GeneroID { get; set; }
        [DisplayName("Grupo")]
        public int? GruposId { get; set; }
    }
}
