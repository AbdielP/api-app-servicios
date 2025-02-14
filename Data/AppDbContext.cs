using api_app_servicios.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Aquí definiremos las tablas (DbSets) más adelante
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Ubicacion> Ubicaciones { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<UsuarioCategoria> UsuarioCategorias { get; set; }
    public DbSet<Permiso> Permisos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relación de muchos a muchos entre Usuario y Categoria
        modelBuilder.Entity<UsuarioCategoria>()
            .HasKey(uc => new { uc.UsuarioId, uc.CategoriaId });
        modelBuilder.Entity<UsuarioCategoria>()
            .HasOne(uc => uc.Usuario)
            .WithMany(u => u.UsuarioCategorias)
            .HasForeignKey(uc => uc.UsuarioId);
        modelBuilder.Entity<UsuarioCategoria>()
            .HasOne(uc => uc.Categoria)
            .WithMany(c => c.UsuarioCategorias)
            .HasForeignKey(uc => uc.CategoriaId);
        // Relación de uno a muchos entre Usuario y Ubicacion
        modelBuilder.Entity<Ubicacion>()
            .HasOne(u => u.Usuario)
            .WithMany(u => u.Ubicaciones)
            .HasForeignKey(u => u.UsuarioId);
        // Relación de uno a muchos entre Usuario y Permiso
        modelBuilder.Entity<Permiso>()
            .HasOne(p => p.Usuario)
            .WithMany(u => u.Permisos)
            .HasForeignKey(p => p.UsuarioId);
    }

}
