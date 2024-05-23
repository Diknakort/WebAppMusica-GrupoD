﻿using System;
using System.Collections.Generic;

namespace WebApplication_MUSICA_grupoD.Models;

public partial class Colaboraciones
{
    public int Id { get; set; }

    public int? GruposID { get; set; }

    public int? ArtistasID { get; set; }

    public virtual Artistas? Artistas { get; set; }

    public virtual Grupos? Grupos { get; set; }
}
