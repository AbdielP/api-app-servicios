using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_app_servicios.Models
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Correo { get; set; } = string.Empty;

        [Required]
        public string Contraseña { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Rol { get; set; } = "cliente"; // Puede ser 'cliente' o 'profesional'

        public string? Ruc { get; set; } // Solo para profesionales
        [Column(TypeName = "timestamp")]
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

        // Relaciones
        public ICollection<UsuarioCategoria>? UsuarioCategorias { get; set; }
        public ICollection<Permiso>? Permisos { get; set; }
        public ICollection<Ubicacion>? Ubicaciones { get; set; }
        public ICollection<Mensaje>? MensajesEnviados { get; set; }
        public ICollection<Mensaje>? MensajesRecibidos { get; set; }
        public ICollection<Calificacion>? CalificacionesDadas { get; set; } // Usuario que califica
        public ICollection<Calificacion>? CalificacionesRecibidas { get; set; } // Profesional que es calificado
        public ICollection<Solicitud>? Solicitudes { get; set; }
        public ICollection<Trabajo>? Trabajos { get; set; }
    }
}
