using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.Data;

public class AppDbContext : DbContext
{
    public DbSet<Advogado> Advogados { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advogado>(entity =>
        {
            entity.HasKey(e => e.IdAdvogado);
        });
        
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);
        });
    }
    
}