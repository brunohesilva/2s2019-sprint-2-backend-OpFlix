using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class OpFlixContext : DbContext
    {
        public OpFlixContext()
        {
        }

        public OpFlixContext(DbContextOptions<OpFlixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Lancamentos> Lancamentos { get; set; }
        public virtual DbSet<MeiosVeiculacao> MeiosVeiculacao { get; set; }
        public virtual DbSet<TipoFilmesSeries> TipoFilmesSeries { get; set; }
        public virtual DbSet<TipoUsuarios> TipoUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        // Unable to generate entity type for table 'dbo.OndeLanca'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=M_OpFlixFinal;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.HasIndex(e => e.Categoria)
                    .HasName("UQ__Categori__08015F8B3650D540")
                    .IsUnique();

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lancamentos>(entity =>
            {
                entity.HasKey(e => e.IdFilmeSerie);

                entity.HasIndex(e => e.Titulo)
                    .HasName("UQ__FilmesSe__7B406B569634AF6D")
                    .IsUnique();

                entity.Property(e => e.DataLancamento).HasColumnType("datetime");

                entity.Property(e => e.Sinopse).HasColumnType("text");

                entity.Property(e => e.TempoDuracao)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__FilmesSer__IdCat__59FA5E80");

                entity.HasOne(d => d.IdTipoFilmeSerieNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdTipoFilmeSerie)
                    .HasConstraintName("FK__FilmesSer__IdTip__5AEE82B9");
            });

            modelBuilder.Entity<MeiosVeiculacao>(entity =>
            {
                entity.HasKey(e => e.IdMeioVeiculacao);

                entity.HasIndex(e => e.MeioVeiculacao)
                    .HasName("UQ__MeiosVei__6BB5DACBBCFCA541")
                    .IsUnique();

                entity.Property(e => e.MeioVeiculacao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoFilmesSeries>(entity =>
            {
                entity.HasKey(e => e.IdTipoFilmeSerie);

                entity.HasIndex(e => e.TipoFilmeSerie)
                    .HasName("UQ__TipoFilm__9BF039F136440AF0")
                    .IsUnique();

                entity.Property(e => e.TipoFilmeSerie)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuarios>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.Property(e => e.TipoUsuario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D105341D0F481D")
                    .IsUnique();

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Usuarios__7D8FE3B2AA817CCB")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuarios__IdTipo__4D94879B");
            });
        }
    }
}
