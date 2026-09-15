using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab05teo.Models;

[Table("proyectos")]
public partial class Proyecto
{
    [Key]
    [Column("id_proyecto")]
    public int IdProyecto { get; set; }

    [Column("id_cliente")]
    public int IdCliente { get; set; }

    [Column("id_responsable")]
    public int IdResponsable { get; set; }

    [Column("nombre")]
    [StringLength(200)]
    public string Nombre { get; set; } = null!;

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [Column("objetivo")]
    public string? Objetivo { get; set; }

    [Column("fecha_inicio")]
    public DateOnly FechaInicio { get; set; }

    [Column("fecha_fin")]
    public DateOnly? FechaFin { get; set; }

    [Column("estado")]
    [StringLength(30)]
    public string? Estado { get; set; }

    [Column("presupuesto")]
    [Precision(10, 2)]
    public decimal? Presupuesto { get; set; }

    [InverseProperty("IdProyectoNavigation")]
    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();

    [ForeignKey("IdCliente")]
    [InverseProperty("Proyectos")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    [ForeignKey("IdResponsable")]
    [InverseProperty("Proyectos")]
    public virtual Empleado IdResponsableNavigation { get; set; } = null!;

    [InverseProperty("IdProyectoNavigation")]
    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
