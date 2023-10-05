using System;
using System.Collections.Generic;

namespace PruebaYeisonLlanes.Models;

public partial class Historicos
{
    public int IdHistorico { get; set; }

    public string? Historico1 { get; set; }

    public DateTime? Fecha { get; set; }

    public int IdUsuario { get; set; }

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
