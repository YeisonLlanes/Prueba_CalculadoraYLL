using System;
using System.Collections.Generic;

namespace PruebaYeisonLlanes.Models;

public partial class Logs
{
    public int IdLog { get; set; }

    public string? Detalle { get; set; }

    public DateTime? Fecha { get; set; }
}
