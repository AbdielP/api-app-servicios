namespace api_app_servicios.Models
{
    public class UsuarioCategoria
    {
        public Guid UsuarioId { get; set; }
        public Guid CategoriaId { get; set; }

        // Relaciones
        public Usuario Usuario { get; set; } = null!;
        public Categoria Categoria { get; set; } = null!;
    }
}
