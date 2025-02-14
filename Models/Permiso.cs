using System.ComponentModel.DataAnnotations;

namespace api_app_servicios.Models
{
    public class Permiso
    {
        [Key]   
        public Guid Id { get; set; }
        [Required]
        public Guid UsuarioId { get; set; }
        [Required, MaxLength(50)]
        public string Tipo { get; set; } = string.Empty;

        // Relacion con Usuario
        public Usuario Usuario { get; set; } = null!;
    }
}
