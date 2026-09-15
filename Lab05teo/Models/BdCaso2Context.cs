using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab05teo.Models;

public partial class BdCaso2Context : DbContext
{
    public BdCaso2Context()
    {
    }

    public BdCaso2Context(DbContextOptions<BdCaso2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Gasto> Gastos { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=bd_caso2;Username=postgres;Password=123eder");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("clientes_pkey");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("empleados_pkey");
        });

        modelBuilder.Entity<Gasto>(entity =>
        {
            entity.HasKey(e => e.IdGasto).HasName("gastos_pkey");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.Gastos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gastos_id_proyecto_fkey");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.IdProyecto).HasName("proyectos_pkey");

            entity.Property(e => e.Estado).HasDefaultValueSql("'Planificado'::character varying");
            entity.Property(e => e.Presupuesto).HasDefaultValue(0m);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Proyectos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proyectos_id_cliente_fkey");

            entity.HasOne(d => d.IdResponsableNavigation).WithMany(p => p.Proyectos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proyectos_id_responsable_fkey");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("tareas_pkey");

            entity.Property(e => e.Estado).HasDefaultValueSql("'Pendiente'::character varying");
            entity.Property(e => e.Progreso).HasDefaultValue(0);

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Tareas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tareas_id_empleado_fkey");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.Tareas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tareas_id_proyecto_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
