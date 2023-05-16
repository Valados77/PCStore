using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PCStore_MVC.Models.ModelDB;

public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string ProductName { get; set; } = null!;

    public int ProducerId { get; set; }

    public int CategoryId { get; set; }

    public Image Image { get; set; } = null!;

	[Column(TypeName = "text")]
    public string? Description { get; set; }

	[Column(TypeName = "money")]
    public decimal UnitPrice { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<BasketProduct> BasketProducts { get; } = new List<BasketProduct>();

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    [ForeignKey("ProducerId")]
    [InverseProperty("Products")]
    public virtual Producer Producer { get; set; } = null!;
}
