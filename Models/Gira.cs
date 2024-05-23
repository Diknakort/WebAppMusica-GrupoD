using System;
using System.Collections.Generic;

namespace WebAppMUSICA.Models;

public partial class Gira
{
    public int Id { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? FechaFinal { get; set; }
}
