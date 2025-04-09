using System.ComponentModel.DataAnnotations;

namespace api_app_servicios.Models
{
    public class Trabajo
    {
        [Key]
        public Guid Id { get; set; }
        public string Estado { get; set; } = string.Empty;
        public DateOnly FechaInicio { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public DateOnly FechaFin { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        // Relacion con solicitud: Uno a uno 1:1
        public Guid SolicitudId { get; set; }
        public Solicitud Solicitud { get; set; } = null!;
        // Relacion con profesional 1:N
        public Guid ProfesionalId { get; set; }
        public Usuario Profesional { get; set; } = null!;
    }
}
