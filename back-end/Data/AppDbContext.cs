using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.Data;

public class AppDbContext : DbContext
{
    public DbSet<Advogado> Advogados { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advogado>(entity =>
        {
            entity.HasKey(e => e.IdAdvogado);

            // entity.HasOne<PessoaFisica>()
            //     .WithMany()
            //     .HasForeignKey(e => e.IdPessoaFisica)
            //     .HasConstraintName("FK_PF_ADV_ID_PESSOA_FISICA");

            entity.HasOne<PessoaJuridica>()
                .WithMany()
                .HasForeignKey(e => e.IdPessoaJuridica)
                .HasConstraintName("FK_PJ_ADV_ID_PESSOA_JURIDICA");

            // entity.HasOne<Usuario>()
            //     .WithMany()
            //     .HasForeignKey(e => e.IdUsuario)
            //     .HasConstraintName("FK_USU_ADV_ID_USUARIO");
        });
    }
    
}