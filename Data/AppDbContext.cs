using Microsoft.EntityFrameworkCore;
using GlobalSolution.Models;

namespace GlobalSolution.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Lembrete> Lembretes { get; set; }
        public DbSet<Localizacao> Localizacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasMany(u => u.Lembretes)
                      .WithOne(l => l.Usuario)
                      .HasForeignKey(l => l.UsuarioId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Lembrete>(entity =>
            {
                entity.ToTable("Lembretes");
            });

            modelBuilder.Entity<Localizacao>(entity =>
            {
                entity.ToTable("Localizacoes");

                entity.Property(e => e.Cep)
                      .HasColumnName("Cep")  
                      .HasMaxLength(8)
                      .IsRequired();

                entity.Property(e => e.Logradouro)
                      .HasColumnName("LOGRADOURO")
                      .HasMaxLength(150)
                      .IsRequired();

                entity.Property(e => e.Numero)
                      .HasColumnName("NUMERO")
                      .HasMaxLength(10)
                      .IsRequired();

                entity.Property(e => e.Complemento)
                      .HasColumnName("COMPLEMENTO")
                      .HasMaxLength(50)
                      .IsRequired(false);

                entity.Property(e => e.Bairro)
                      .HasColumnName("BAIRRO")
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Cidade)
                      .HasColumnName("CIDADE")
                      .HasMaxLength(100)
                      .IsRequired();

                entity.HasMany(l => l.Usuarios)
                      .WithOne(u => u.Localizacao)
                      .HasForeignKey(u => u.LocalizacaoId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
