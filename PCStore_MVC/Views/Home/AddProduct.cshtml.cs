using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PCStore_MVC.Data;
using PCStore_MVC.Models.ModelDB;

namespace PCStore_MVC.Views.Home
{
    public class AddProductModel : PageModel
    {
	    private readonly ApplicationDbContext db;

	    public AddProductModel(ApplicationDbContext injectedContext)
	    {
		    db = injectedContext;
	    }

		public void OnGet()
        {
        }

        [BindProperty]
        public Product? Product { get; set; }
        public IActionResult OnPost()
        {
	        if ((Product is not null) && ModelState.IsValid)
	        {
		        db.Products.Add(Product);
		        db.SaveChanges();
		        return RedirectToPage("/suppliers");
	        }
	        else
	        {
		        return Page(); // return to original page
	        }
        }
	}
}
