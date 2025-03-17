using System.ComponentModel.DataAnnotations;

namespace api_app_servicios.Models
{
    public class Ubicacion
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UsuarioId { get; set; }
        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string Direccion { get; set; } = string.Empty;
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        [MaxLength(50)]
        public string Tipo { get; set; } = "residencial"; // Puede ser 'residencial' o 'comerial'
        // Relacion con usuario 1:N
        public required Usuario Usuario { get; set; }
    }
}
