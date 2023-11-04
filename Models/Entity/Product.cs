using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebPhoneEcommerce.Models.Entity;

[Table("Product")]
public partial class Product
{
    [Key]
    [StringLength(100)]
    public string Id { get; set; } = null!;

    [StringLength(20)]
    public string? ProductId { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }

    [Column(TypeName = "numeric(28, 8)")]
    public decimal? UnitPrice { get; set; }

    [StringLength(255)]
    public string? Filter { get; set; }

    [StringLength(255)]
    public string? Urlimg { get; set; }
}
