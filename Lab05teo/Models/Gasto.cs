using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab05teo.Models;

[Table("gastos")]
public partial class Gasto
{
    [Key]
    [Column("id_gasto")]
    public int IdGasto { get; set; }

    [Column("id_proyecto")]
    public int IdProyecto { get; set; }

    [Column("concepto")]
    [StringLength(200)]
    public string Concepto { get; set; } = null!;

    [Column("monto")]
    [Precision(10, 2)]
    public decimal Monto { get; set; }

    [Column("fecha_gasto")]
    public DateOnly FechaGasto { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [ForeignKey("IdProyecto")]
    [InverseProperty("Gastos")]
    public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
}
