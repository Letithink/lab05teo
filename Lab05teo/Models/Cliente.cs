using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab05teo.Models;

[Table("clientes")]
public partial class Cliente
{
    [Key]
    [Column("id_cliente")]
    public int IdCliente { get; set; }

    [Column("nombre_empresa")]
    [StringLength(150)]
    public string NombreEmpresa { get; set; } = null!;

    [Column("nombre_contacto")]
    [StringLength(100)]
    public string? NombreContacto { get; set; }

    [Column("correo")]
    [StringLength(150)]
    public string? Correo { get; set; }

    [Column("telefono")]
    [StringLength(20)]
    public string? Telefono { get; set; }

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}
