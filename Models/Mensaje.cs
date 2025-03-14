using System.ComponentModel.DataAnnotations;

namespace api_app_servicios.Models
{
    public class Mensaje
    {
        [Key]
        public Guid Id { get; set; }
        public string Contenido { get; set; } = string.Empty;
        public DateTime FechaEnvio { get; set; } = DateTime.UtcNow;

        // Relacion con Usuario que envia el mensaje: Uno a muchos 1:N 
        public Guid RemitenteId { get; set; }
        public Usuario Remitente { get; set; } = null!;

        // Relacion con Usuario que recibe el mensaje: Uno a muchos 1:N
        public Guid DestinatarioId { get; set; }
        public Usuario Destinatario { get; set; } = null!;
    }
}
