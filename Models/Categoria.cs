using System.ComponentModel.DataAnnotations;

namespace api_app_servicios.Models
{
    public class Categoria
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public string? Icono { get; set; }

        // Relacion con usuarios (muchos a muchos)
        public ICollection<UsuarioCategoria>? UsuarioCategorias { get; set; }
        // Relacion con solicitudes 1:N
        public ICollection<Solicitud>? Solicitudes { get; set; }
    }
}
