using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infrastructure.Data
{
    public partial class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CentroSalud> CentroSaluds { get; set; }
        public virtual DbSet<Colaborador> Colaboradors { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }
        public virtual DbSet<Maquina> Maquinas { get; set; }
        public virtual DbSet<Reporte> Reportes { get; set; }
        public virtual DbSet<Solicitud> Solicituds { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-B14EN9G\\RYZEN7;Initial Catalog=ClenicBD;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<CentroSalud>(entity =>
            {
                entity.HasKey(e => e.IdCentroSalud)
                    .HasName("Sanatorio_pk");

                entity.ToTable("CentroSalud");

                entity.Property(e => e.IdCentroSalud).ValueGeneratedNever();

                entity.Property(e => e.Tdireccion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("TDireccion");

                entity.Property(e => e.Tencargado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TEncargado");

                entity.Property(e => e.TrazonSocial)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TRazonSocial");

                entity.Property(e => e.Truc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("TRUC");

                entity.HasOne(d => d.IdCentroSaludNavigation)
                    .WithOne(p => p.CentroSalud)
                    .HasForeignKey<CentroSalud>(d => d.IdCentroSalud)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sanatorio_Usuario");
            });

            modelBuilder.Entity<Colaborador>(entity =>
            {
                entity.HasKey(e => e.IdColaborador)
                    .HasName("Ingeniero_pk");

                entity.ToTable("Colaborador");

                entity.Property(e => e.IdColaborador).ValueGeneratedNever();

                entity.Property(e => e.Tdireccion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("TDireccion");

                entity.Property(e => e.Tdni)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TDNI");

                entity.Property(e => e.Testado)
                    .HasMaxLength(1)
                    .HasColumnName("TEstado");

                entity.Property(e => e.Tnombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TNombre");

                entity.Property(e => e.TtipoColaborador).HasColumnName("TTipoColaborador");

                entity.HasOne(d => d.IdColaboradorNavigation)
                    .WithOne(p => p.Colaborador)
                    .HasForeignKey<Colaborador>(d => d.IdColaborador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ingeniero_Usuario");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Colaboradors)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ingeniero_Empresa");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("Empresa_pk");

                entity.ToTable("Empresa");

                entity.Property(e => e.IdEmpresa).ValueGeneratedNever();

                entity.Property(e => e.Tdireccion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("TDireccion");

                entity.Property(e => e.TrazonSocial)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TRazonSocial");

                entity.Property(e => e.Truc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("TRUC");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithOne(p => p.Empresa)
                    .HasForeignKey<Empresa>(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Empresa_Usuario");
            });

            modelBuilder.Entity<Mantenimiento>(entity =>
            {
                entity.HasKey(e => e.IdMantenimiento)
                    .HasName("Mantenimiento_pk");

                entity.ToTable("Mantenimiento");

                entity.Property(e => e.Dfecha)
                    .HasColumnType("date")
                    .HasColumnName("DFecha");

                entity.Property(e => e.QestadoIngeniero).HasColumnName("QEstadoIngeniero");

                entity.Property(e => e.QestadoMantenimiento).HasColumnName("QEstadoMantenimiento");

                entity.Property(e => e.Testado)
                    .HasMaxLength(1)
                    .HasColumnName("TEstado");

                entity.HasOne(d => d.IdIngenieroNavigation)
                    .WithMany(p => p.Mantenimientos)
                    .HasForeignKey(d => d.IdIngeniero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Mantenimiento_Ingeniero");

                entity.HasOne(d => d.IdSolicitudNavigation)
                    .WithMany(p => p.Mantenimientos)
                    .HasForeignKey(d => d.IdSolicitud)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Mantenimiento_Solicitud");
            });

            modelBuilder.Entity<Maquina>(entity =>
            {
                entity.HasKey(e => e.IdMaquina)
                    .HasName("Maquina_pk");

                entity.ToTable("Maquina");

                entity.Property(e => e.IdMaquina).ValueGeneratedNever();

                entity.Property(e => e.FincidenteDetectado).HasColumnName("FIncidenteDetectado");

                entity.Property(e => e.FioTintegrado).HasColumnName("FIoTIntegrado");

                entity.Property(e => e.Tmarca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TMarca");

                entity.Property(e => e.Tmodelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TModelo");

                entity.Property(e => e.Tserie)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TSerie");

                entity.Property(e => e.Ttipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TTipo");

                entity.HasOne(d => d.IdSanatorioNavigation)
                    .WithMany(p => p.Maquinas)
                    .HasForeignKey(d => d.IdSanatorio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Maquina_Sanatorio");
            });

            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.HasKey(e => e.IdReporte)
                    .HasName("Reporte_pk");

                entity.ToTable("Reporte");

                entity.Property(e => e.IdReporte).ValueGeneratedNever();

                entity.Property(e => e.Dfecha)
                    .HasColumnType("date")
                    .HasColumnName("DFecha");

                entity.Property(e => e.Qcalificacion).HasColumnName("QCalificacion");

                entity.Property(e => e.Tcomentarios)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TComentarios");

                entity.HasOne(d => d.IdMantenimientoNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdMantenimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reporte_Mantenimiento");
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.HasKey(e => e.IdSolicitud)
                    .HasName("Solicitud_pk");

                entity.ToTable("Solicitud");

                entity.Property(e => e.Tdescripcion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("TDescripcion");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Solicituds)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Solicitud_Empresa");

                entity.HasOne(d => d.IdMaquinaNavigation)
                    .WithMany(p => p.Solicituds)
                    .HasForeignKey(d => d.IdMaquina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Solicitud_Maquina");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("Usuario_pk");

                entity.ToTable("Usuario");

                entity.Property(e => e.Tpassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TPassword");

                entity.Property(e => e.TtipoUsuario).HasColumnName("TTipoUsuario");

                entity.Property(e => e.Tusername)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TUsername");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
