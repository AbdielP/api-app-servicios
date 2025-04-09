using System.ComponentModel.DataAnnotations;

namespace api_app_servicios.Models
{
    public class Calificacion
    {
        [Key]
        public Guid Id { get; set; }
        public double Puntuacion { get; set; }
        [MaxLength(300)]
        public string Comentario { get; set; } = string.Empty;
        public DateTime FechaCalificacion { get; set; } = DateTime.UtcNow;

        // Relación 1:1 con trabajo  
        public Guid TrabajoId { get; set; }
        public Trabajo Trabajo { get; set; } = null!;

        // Relación con usuario que califica: Uno a muchos 1:N
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        // Relación con profesional que es calificado: Uno a muchos 1:N
        public Guid ProfesionalId { get; set; }
        public Usuario Profesional { get; set; } = null!;
    }
}
// Unicamente el usuario que solicita el trabajo puede calificar al profesional que lo realizó.