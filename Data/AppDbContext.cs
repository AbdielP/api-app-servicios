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
    public DbSet<Mensaje> Mensajes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mensaje>()
            .HasOne(m => m.Remitente)
            .WithMany(u => u.MensajesEnviados)
            .HasForeignKey(m => m.RemitenteId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Mensaje>()
            .HasOne(m => m.Destinatario)
            .WithMany(u => u.MensajesRecibidos)
            .HasForeignKey(m => m.DestinatarioId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Permiso>()
            .HasOne(p => p.Usuario)
            .WithMany(u => u.Permisos)
            .HasForeignKey(p => p.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Ubicacion>()
            .HasOne(u => u.Usuario)
            .WithMany(u => u.Ubicaciones)
            .HasForeignKey(u => u.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Calificacion>()
            .HasOne(c => c.Usuario)
            .WithMany(u => u.CalificacionesDadas)
            .HasForeignKey(c => c.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Calificacion>()
            .HasOne(c => c.Profesional)
            .WithMany(u => u.CalificacionesRecibidas)
            .HasForeignKey(c => c.ProfesionalId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<UsuarioCategoria>()
            .HasKey(uc => new { uc.UsuarioId, uc.CategoriaId });


    }

}
