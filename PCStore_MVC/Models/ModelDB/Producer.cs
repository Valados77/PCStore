using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PCStore_MVC.Models.ModelDB;

public partial class Producer
{
    [Key]
    public int ProducerId { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string ProducerName { get; set; } = null!;

    [StringLength(15)]
    public string City { get; set; } = null!;

    [InverseProperty("Producer")]
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
