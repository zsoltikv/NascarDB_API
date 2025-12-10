using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("cup series")]
public partial class CupSeries
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("season")]
    public int? Season { get; set; }

    [Column("races")]
    public int? Races { get; set; }

    [Column("champion")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Champion { get; set; }

    [Column("manufacturer")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Manufacturer { get; set; }
}
