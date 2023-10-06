using System.ComponentModel.DataAnnotations;

namespace PruebaYeisonLlanes.Models
{
    public class GetHistoricos
    {
        [Key]
        public int IdHistorico { get; set; }

        public string? Historico { get; set; }

        public DateTime? Fecha { get; set; }

        public int IdUsuario { get; set; }

        public string? Usuario { get; set; }
    }
}
