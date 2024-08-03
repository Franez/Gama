using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoGama.Models;

public partial class DbgamaContext : DbContext
{
    public DbgamaContext()
    {
    }

    public DbgamaContext(DbContextOptions<DbgamaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipo> Equipos { get; set; }
    public virtual DbSet<PosicionesFutbol> PosicionesFutbols { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.IdequipoFutbol).HasName("PK__Equipos__034DC40F63F4810E");

            entity.Property(e => e.IdequipoFutbol).HasColumnName("IDEquipoFutbol");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Entrenador).HasMaxLength(100);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreEquipo).HasMaxLength(100);
        });

        modelBuilder.Entity<PosicionesFutbol>(entity =>
        {
            entity.HasKey(e => e.PosicionId).HasName("PK__Posicion__FCC1023610C60A99");

            entity.ToTable("PosicionesFutbol");

            entity.Property(e => e.PosicionId)
                .ValueGeneratedNever()
                .HasColumnName("PosicionID");
            entity.Property(e => e.NombrePosicion).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC27E24C1CF2");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nacionalidad).HasMaxLength(50);
            entity.Property(e => e.NombreCompleto).HasMaxLength(100);

            entity.HasOne(d => d.EquipoActualNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.EquipoActual)
                .HasConstraintName("FK_EquipoActual");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
