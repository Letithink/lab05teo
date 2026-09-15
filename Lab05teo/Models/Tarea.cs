using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab05teo.Models;

[Table("tareas")]
public partial class Tarea
{
    [Key]
    [Column("id_tarea")]
    public int IdTarea { get; set; }

    [Column("id_proyecto")]
    public int IdProyecto { get; set; }

    [Column("id_empleado")]
    public int IdEmpleado { get; set; }

    [Column("nombre")]
    [StringLength(200)]
    public string Nombre { get; set; } = null!;

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [Column("fecha_inicio")]
    public DateOnly? FechaInicio { get; set; }

    [Column("fecha_limite")]
    public DateOnly? FechaLimite { get; set; }

    [Column("estado")]
    [StringLength(30)]
    public string? Estado { get; set; }

    [Column("progreso")]
    public int? Progreso { get; set; }

    [ForeignKey("IdEmpleado")]
    [InverseProperty("Tareas")]
    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    [ForeignKey("IdProyecto")]
    [InverseProperty("Tareas")]
    public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
}
