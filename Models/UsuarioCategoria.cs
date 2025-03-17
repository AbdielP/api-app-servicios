namespace api_app_servicios.Models
{
    public class UsuarioCategoria
    {
        // Clave foránea: Usuario asociado a esta relación M:N
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        // Clave foránea: Categoria asociada a esta relación M:N
        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; } = null!;
    }
}
