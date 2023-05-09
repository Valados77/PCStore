using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PCStore_MVC.Models.ModelDB
{
    [Index("UserName", Name = "UQ__Users__C9F28456613B9462", IsUnique = true)]
    public partial class User : IdentityUser
    {
        [StringLength(32)]
        [Unicode(false)]
        public string FirstName { get; set; } = null!;

        [StringLength(32)]
        [Unicode(false)]
        public string LastName { get; set; } = null!;

        [StringLength(128)]
        [Unicode(false)]
        public string PhysycalAddress { get; set; } = null!;

        [Column(TypeName = "image")]
        public byte[]? ProfilePicture { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<BasketProduct> BasketProducts { get; } = new List<BasketProduct>();

        [InverseProperty("User")]
        public virtual ICollection<Order> Orders { get; } = new List<Order>();
    }
}