using api_app_servicios.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Aquí definiremos las tablas (DbSets) más adelante
    public DbSet<Usuario> Usuarios { get; set; }

}
