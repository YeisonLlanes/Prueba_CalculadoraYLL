using System;
using System.Collections.Generic;

namespace PruebaYeisonLlanes.Models;

public partial class Operadores
{
    public int IdOperador { get; set; }

    public string? Operador { get; set; }

    public int? IdPrioridad { get; set; }

    public int? IdUbicacion { get; set; }

    public virtual Prioridades? IdPrioridadNavigation { get; set; }

    public virtual Ubicaciones? IdUbicacionNavigation { get; set; }
}
