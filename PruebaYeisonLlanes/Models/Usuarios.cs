using System;
using System.Collections.Generic;

namespace PruebaYeisonLlanes.Models;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public string? Usuario { get; set; }

    public virtual ICollection<Historicos> Historicos { get; set; } = new List<Historicos>();
}
