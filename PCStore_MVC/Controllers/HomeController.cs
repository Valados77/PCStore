using Microsoft.AspNetCore.Mvc;
using PCStore_MVC.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PCStore_MVC.Data;

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

        [ResponseCache(Duration = 10,
            Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Index()
        {
            HomeIndexViewModel model = new
            (
                Users: await db.Users.ToListAsync(),
                Categories: await db.Categories.ToListAsync(),
                Products: await db.Products.ToListAsync()
            );

            return View(model);
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

        public IActionResult CategoryDetail(int categoryId)
        {
            var products = db.Products
	            .Include(p => p.Category)
	            .Include(p => p.Producer)
	            .Include(p=> p.Image)
	            .Where(p => p.Category.CategoryId == categoryId).ToList();

            ViewData["Title"] = db.Categories.FirstOrDefault(p => p.CategoryId == categoryId).CategoryName;
			return View(products);
        }
    }
}