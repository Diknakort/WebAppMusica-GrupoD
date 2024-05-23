using System;
using System.Collections.Generic;

namespace WebAppMUSICA.Models;

public partial class Roles
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Artistas> Artistas { get; set; } = new List<Artistas>();
}
