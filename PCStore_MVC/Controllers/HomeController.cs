using Microsoft.AspNetCore.Mvc;
using PCStore_MVC.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PCStore_MVC.Data;
using PCStore_MVC.Models.ModelDB;

namespace PCStore_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger,
            ApplicationDbContext injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        [ResponseCache(Duration = 10 /* seconds */,
            Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Index()
        {
            HomeIndexViewModel model = new
            (
                Users: await db.Users.ToListAsync(),
                Categories: await db.Categories.ToListAsync(),
                Products: await db.Products.ToListAsync()
            );

            return View(model); // pass model to view
        }

		[Route("private")]
		[Authorize(Roles = "Administrators")]
		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public IActionResult CategoryDetail(int? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        return BadRequest("You must pass a category ID in the route, for example, /Home/CategoryDetail/21");
        //    }

        //    Category? model = db.Categories.SingleOrDefault(p => p.CategoryId == id);
        //    if (model is null)
        //    {
        //        return NotFound($"CategoryId {id} not found.");
        //    }

        //    return View(model); // pass model to view and then return result
        //}

        public IActionResult CategoryProducts(int? id)
        {
	        if (!id.HasValue)
	        {
		        return BadRequest("You must pass a category ID in the route, for example, /Home/CategoryDetail/21");
	        }

	        Category? model = db.Categories.SingleOrDefault(c => c.CategoryId == id);
	        if (model is null)
	        {
		        return NotFound($"CategoryId {id} not found.");
	        }

	        return View(model); // pass model to view and then return result
        }
	}
}