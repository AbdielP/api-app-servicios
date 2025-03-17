using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_app_servicios.Models
{
    public class Solicitud
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Direccion { get; set; } = string.Empty;
        [Column(TypeName = "numeric(9,6)")]
        public decimal Latitud { get; set; } = 0;
        [Column(TypeName = "numeric(9,6)")]
        public decimal Longitud { get; set; } = 0;
        public string Descripcion { get; set; } = string.Empty;
        [Column(TypeName = "timestamp")]
        public DateTime Fecha_preferida { get; set; }
        public decimal Presupuesto { get; set; } = 0;
        public string Estado { get; set; } = string.Empty;
        [Column(TypeName = "timestamp")]
        public DateTime Fecha_creacion { get; set; } = DateTime.UtcNow;
        // FALTAN RELACIONES
    }
}
