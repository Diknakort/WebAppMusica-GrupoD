using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace WebApplication_MUSICA_grupoD.Models;

public partial class Artistas
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
    
    public virtual ICollection<Colaboraciones> Colaboraciones { get; set; } = new List<Colaboraciones>();
    [DisplayName("El rol/instrumento principal")]
    public virtual Roles? RolPrincipalNavigation { get; set; }
}
