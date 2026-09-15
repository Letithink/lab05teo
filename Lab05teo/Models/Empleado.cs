using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab05teo.Models;

[Table("empleados")]
[Index("Correo", Name = "empleados_correo_key", IsUnique = true)]
public partial class Empleado
{
    [Key]
    [Column("id_empleado")]
    public int IdEmpleado { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("apellido")]
    [StringLength(100)]
    public string Apellido { get; set; } = null!;

    [Column("correo")]
    [StringLength(150)]
    public string Correo { get; set; } = null!;

    [Column("cargo")]
    [StringLength(100)]
    public string? Cargo { get; set; }

    [Column("telefono")]
    [StringLength(20)]
    public string? Telefono { get; set; }

    [InverseProperty("IdResponsableNavigation")]
    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();

    [InverseProperty("IdEmpleadoNavigation")]
    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
