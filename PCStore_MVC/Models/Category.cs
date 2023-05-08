using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PCStore.MVC.Models;

public partial class Category
{
    [Key]
    public int CategoryId { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string CategoryName { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [Column(TypeName = "image")]
    public byte[]? Picture { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
