using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AgenceTestApplication.Models;

#nullable disable

namespace AgenceTestApplication.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CaoFatura> CaoFaturas { get; set; }
        public virtual DbSet<CaoO> CaoOs { get; set; }
        public virtual DbSet<CaoSalario> CaoSalarios { get; set; }
        public virtual DbSet<CaoUsuario> CaoUsuarios { get; set; }
        public virtual DbSet<PermissaoSistema> PermissaoSistemas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_unicode_ci");

            modelBuilder.Entity<CaoFatura>(entity =>
            {
                entity.HasKey(e => e.CoFatura)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.DataEmissao).HasDefaultValueSql("'0000-00-00'");
            });

            modelBuilder.Entity<CaoO>(entity =>
            {
                entity.HasKey(e => e.CoOs)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.CoArquitetura).HasDefaultValueSql("'0'");

                entity.Property(e => e.CoSistema).HasDefaultValueSql("'0'");

                entity.Property(e => e.CoStatus).HasDefaultValueSql("'0'");

                entity.Property(e => e.CoUsuario).HasDefaultValueSql("'0'");

                entity.Property(e => e.DiretoriaSol).HasDefaultValueSql("'0'");

                entity.Property(e => e.DsCaracteristica).HasDefaultValueSql("'0'");

                entity.Property(e => e.DsOs).HasDefaultValueSql("'0'");

                entity.Property(e => e.NuTelSol).HasDefaultValueSql("'0'");

                entity.Property(e => e.UsuarioSol).HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CaoSalario>(entity =>
            {
                entity.HasKey(e => new { e.CoUsuario, e.DtAlteracao })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.CoUsuario).HasDefaultValueSql("''");

                entity.Property(e => e.DtAlteracao).HasDefaultValueSql("'0000-00-00'");
            });

            modelBuilder.Entity<CaoUsuario>(entity =>
            {
                entity.HasKey(e => e.CoUsuario)
                    .HasName("PRIMARY");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.CoUsuario).HasDefaultValueSql("''");

                entity.Property(e => e.CoUsuarioAutorizacao)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DsBairro)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DsCompEnd)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DsEndereco)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DsSenha)
                    .HasDefaultValueSql("''")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DtAdmissaoEmpresa).HasDefaultValueSql("'0000-00-00'");

                entity.Property(e => e.DtAlteracao).HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.DtExpiracao).HasDefaultValueSql("'0000-00-00'");

                entity.Property(e => e.DtInclusao).HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.DtNascimento).HasDefaultValueSql("'0000-00-00'");

                entity.Property(e => e.InstantMessenger)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Msn)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NoCidade)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NoEmail)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NoEmailPessoal)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NoOrgaoEmissor)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NoUsuario)
                    .HasDefaultValueSql("''")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NuCep)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NuCpf)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NuRg)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NuTelefone)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.UfCidade)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.UfOrgaoEmissor)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.UrlFoto)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Yms)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<PermissaoSistema>(entity =>
            {
                entity.HasKey(e => new { e.CoUsuario, e.CoTipoUsuario, e.CoSistema })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.CoUsuario).HasDefaultValueSql("''");

                entity.Property(e => e.CoUsuarioAtualizacao)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DtAtualizacao).HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.InAtivo)
                    .HasDefaultValueSql("'S'")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
