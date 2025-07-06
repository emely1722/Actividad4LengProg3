using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Actividad4LengProg3.Models;

public partial class BdActividad4Context : DbContext
{
    public BdActividad4Context()
    {
    }

    public BdActividad4Context(DbContextOptions<BdActividad4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Calificacione> Calificaciones { get; set; }

    public virtual DbSet<EstudianteViewModel> Estudiantes { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-0HDEU2U1;Database=BD_ACTIVIDAD4;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calificacione>(entity =>
        {
            entity.HasKey(e => e.IdCalificaciones).HasName("PK__CALIFICA__804182E066551148");

            entity.ToTable("CALIFICACIONES");

            entity.Property(e => e.IdCalificaciones).HasColumnName("ID_CALIFICACIONES");
            entity.Property(e => e.CodigoMateria)
                .HasMaxLength(20)
                .HasColumnName("CODIGO_MATERIA");
            entity.Property(e => e.MatriculaEstudiante)
                .HasMaxLength(15)
                .HasColumnName("MATRICULA_ESTUDIANTE");
            entity.Property(e => e.Nota)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("NOTA");
            entity.Property(e => e.Periodo)
                .HasMaxLength(20)
                .HasColumnName("PERIODO");

            entity.HasOne(d => d.CodigoMateriaNavigation).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.CodigoMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CALIFICAC__CODIG__6A30C649");

            entity.HasOne(d => d.MatriculaEstudianteNavigation).WithMany(p => p.Calificaciones)
                .HasPrincipalKey(p => p.Matricula)
                .HasForeignKey(d => d.MatriculaEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CALIFICAC__MATRI__693CA210");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("PK__ESTUDIAN__559808808627BE79");

            entity.ToTable("ESTUDIANTES");

            entity.HasIndex(e => e.Matricula, "UQ__ESTUDIAN__46A2F688B91EF6D7").IsUnique();

            entity.Property(e => e.IdEstudiante).HasColumnName("ID_ESTUDIANTE");
            entity.Property(e => e.Carrera)
                .HasMaxLength(100)
                .HasColumnName("CARRERA");
            entity.Property(e => e.CorreoInstitucional)
                .HasMaxLength(255)
                .HasColumnName("CORREO_INSTITUCIONAL");
            entity.Property(e => e.EstaBecado).HasColumnName("ESTA_BECADO");
            entity.Property(e => e.FechaNac).HasColumnName("FECHA_NAC");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .HasColumnName("GENERO");
            entity.Property(e => e.Matricula)
                .HasMaxLength(15)
                .HasColumnName("MATRICULA");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_COMPLETO");
            entity.Property(e => e.PorcentajeBeca).HasColumnName("PORCENTAJE_BECA");
            entity.Property(e => e.Telefono).HasColumnName("TELEFONO");
            entity.Property(e => e.TerminosCondiciones).HasColumnName("TERMINOS_CONDICIONES");
            entity.Property(e => e.TipoIngreso)
                .HasMaxLength(50)
                .HasColumnName("TIPO_INGRESO");
            entity.Property(e => e.Turno)
                .HasMaxLength(10)
                .HasColumnName("TURNO");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.CodigoMateria).HasName("PK__MATERIAS__2215C9230849BFEA");

            entity.ToTable("MATERIAS");

            entity.Property(e => e.CodigoMateria)
                .HasMaxLength(20)
                .HasColumnName("CODIGO_MATERIA");
            entity.Property(e => e.Carrera)
                .HasMaxLength(100)
                .HasColumnName("CARRERA");
            entity.Property(e => e.Creditos).HasColumnName("CREDITOS");
            entity.Property(e => e.NombreMateria)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_MATERIA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
