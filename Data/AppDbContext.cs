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
    public DbSet<Calificacion> Calificaciones { get; set; }
    public DbSet<Solicitud> Solicitudes { get; set; }
    public DbSet<Postulacion> Postulaciones { get; set; }

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
        modelBuilder.Entity<Postulacion>()
            .HasOne(p => p.Solicitud)
            .WithMany(s => s.Postulaciones)
            .HasForeignKey(p => p.SolicitudId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Postulacion>()
            .HasOne(p => p.Profesional)
            .WithMany(u => u.Postulaciones)
            .HasForeignKey(p => p.ProfesionalId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Trabajo>()
            .HasOne(t => t.Solicitud)
            .WithOne(s => s.Trabajo)
            .HasForeignKey<Trabajo>(t => t.SolicitudId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Trabajo>()
            .HasOne(t => t.Profesional)
            .WithMany(u => u.Trabajos)
            .HasForeignKey(t => t.ProfesionalId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Calificacion>()
            .HasOne(c => c.Trabajo)
            .WithOne()
            .HasForeignKey<Calificacion>(c => c.TrabajoId)
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
    }

}
