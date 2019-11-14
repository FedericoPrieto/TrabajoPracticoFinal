using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RapiTurnos.Models;
namespace RapiTurnos.Models
{
    public partial class TurnosWebContext : DbContext
    {

       

    
        
        public virtual DbSet<DuracionTurnos> DuracionTurnos { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<EmpresasServicios> EmpresasServicios { get; set; }
        public virtual DbSet<Localidades> Localidades { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<PersonasServicios> PersonasServicios { get; set; }
        public virtual DbSet<Rubros> Rubros { get; set; }
        public virtual DbSet<SubRubros> SubRubros { get; set; }


        public TurnosWebContext(DbContextOptions<TurnosWebContext> options)
        : base(options)
        {
        }

    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<DuracionTurnos>(entity =>
            {
                entity.HasKey(e => e.IdDuracionTurno);

                entity.Property(e => e.IdDuracionTurno).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa);

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Latitud)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Longitud)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.RubroId).HasColumnName("RubroID");

                entity.HasOne(d => d.IdLocalidadNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdLocalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empresas_Localidades");

                entity.HasOne(d => d.Rubro)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.RubroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empresas_Rubros");
            });

            modelBuilder.Entity<EmpresasServicios>(entity =>
            {
                entity.HasKey(e => e.IdServicio);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta).HasColumnType("smalldatetime");

                entity.Property(e => e.PrecioSugerido).HasColumnType("money");

                entity.HasOne(d => d.IdDuracionTurnoNavigation)
                    .WithMany(p => p.EmpresasServicios)
                    .HasForeignKey(d => d.IdDuracionTurno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmpresasServicios_DuracionTurnos");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.EmpresasServicios)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmpresasServicios_Empresas");
            });

          

            modelBuilder.Entity<Localidades>(entity =>
            {
                entity.HasKey(e => e.IdLocalidad);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Personas>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Lugar)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdDuracionTurnoNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdDuracionTurno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personas_DuracionTurno");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personas_Empresas");
            });

            modelBuilder.Entity<PersonasServicios>(entity =>
            {
                entity.HasKey(e => e.IdPersonaServicio);

                entity.Property(e => e.PrecioSugerido).HasColumnType("money");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.PersonasServicios)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonasServicios_Personas");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.PersonasServicios)
                    .HasForeignKey(d => d.IdServicio)
                    .HasConstraintName("FK_PersonasServicios_EmpresasServicios");
            });

            modelBuilder.Entity<Rubros>(entity =>
            {
                entity.HasKey(e => e.RubroId);

                entity.Property(e => e.RubroId)
                    .HasColumnName("RubroID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<SubRubros>(entity =>
            {
                entity.HasKey(e => e.SubRubroId);

                entity.Property(e => e.SubRubroId).HasColumnName("SubRubroID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RubroId).HasColumnName("RubroID");

                entity.HasOne(d => d.Rubro)
                    .WithMany(p => p.SubRubros)
                    .HasForeignKey(d => d.RubroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubRubros_Rubros");
            });
        }
    }

}

