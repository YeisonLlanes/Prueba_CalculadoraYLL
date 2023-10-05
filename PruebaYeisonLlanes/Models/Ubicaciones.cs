using System;
using System.Collections.Generic;

namespace PruebaYeisonLlanes.Models;

public partial class Ubicaciones
{
    public int IdUbicacion { get; set; }

    public string? Ubicacion { get; set; }

    public virtual ICollection<Operadores> Operadores { get; set; } = new List<Operadores>();
}
