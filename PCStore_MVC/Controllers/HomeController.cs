using Microsoft.AspNetCore.Mvc;
using PCStore_MVC.Models;
using System.Diagnostics;
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

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}