using Microsoft.AspNetCore.Identity;
using PCStore_MVC.Models.ModelDB;

namespace PCStore_MVC.Models
{
	public record HomeIndexViewModel
	(
		IList<IdentityUser> Users,
		IList<Category> Categories,
		IList<Product> Products
	);
}
