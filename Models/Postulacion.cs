using System.ComponentModel.DataAnnotations;

namespace api_app_servicios.Models
{
    public class Postulacion
    {
        [Key]
        public Guid Id { get; set; }

        [Required] //Relación con Solicitud
        public Guid SolicitudId { get; set; }
        public Solicitud Solicitud { get; set; } = null!;

        [Required] //Relación con Profesional
        public Guid ProfesionalId { get; set; }
        public Usuario Profesional { get; set; } = null!;
        [Required]
        public int Presupuesto { get; set; } = 0;
        public string TiempoEstimado { get; set; } = string.Empty;
        [MaxLength(250)]
        public string Mensaje { get; set; } = string.Empty;
        public string Estado { get; set; } = "pendiente"; // pendiente, aceptada, rechazada
        public DateTime FechaPostulacion { get; set; } = DateTime.UtcNow;

    }
}
