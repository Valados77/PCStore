using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PCStore.MVC.Models;

[PrimaryKey("UserId", "ProductId")]
public partial class BasketProduct
{
    [Key]
    public string UserId { get; set; }

    [Key]
    public int ProductId { get; set; }

    public int Count { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("BasketProducts")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("BasketProducts")]
    public virtual User User { get; set; } = null!;
}
