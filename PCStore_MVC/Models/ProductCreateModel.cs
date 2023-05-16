using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCStore_MVC.Models
{
    public class ProductCreateModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Unicode(false)]
        [StringLength(256)]
        public string ProductName { get; set; } = null!;

        // Int max min
        [Required]
        public int ProducerId { get; set; }

        // Int max min
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [Required]
        public IFormFile File { get; set; } = null!;
    }
}
