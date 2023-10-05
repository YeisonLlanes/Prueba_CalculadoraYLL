using System;
using System.Collections.Generic;

namespace PruebaYeisonLlanes.Models;

public partial class Prioridades
{
    public int IdPrioridades { get; set; }

    public string? Prioridad { get; set; }

    public virtual ICollection<Operadores> Operadores { get; set; } = new List<Operadores>();
}
