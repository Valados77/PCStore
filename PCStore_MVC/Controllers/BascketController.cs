using Microsoft.AspNetCore.Mvc;
using PCStore_MVC.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PCStore_MVC.Data;
using PCStore_MVC.Models.ModelDB;
using SendGrid.Helpers.Mail;


namespace PCStore_MVC.Controllers
{
    public class BascketController: Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        public BascketController(ILogger<HomeController> logger,
            ApplicationDbContext injectedContext,
            UserManager<ApplicationUser> um)
        {
            _logger = logger;
            db = injectedContext;
            _userManager= um;
        }

        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
	        var product = db.Products.FirstOrDefault(p => p.ProductId == productId);
	        var user = await _userManager.GetUserAsync(HttpContext.User);

			if (product != null)
	        {
				//// получаем корзину из сессии
				//var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();

				//// добавляем товар в корзину
				//cart.AddItem(product, quantity);

				//// сохраняем изменения в сессию
				//HttpContext.Session.SetObjectAsJson("Cart", cart);

				BasketProduct basketProduct = new BasketProduct()
				{
					ProductId = productId,
					UserId = user.Id,
					Count = quantity,
				};

				await db.BasketProducts.AddAsync(basketProduct);
				await db.SaveChangesAsync();
			}

	        // возвращаем пользователя на страницу корзины
	        return RedirectToAction("CategoryDetail", "Home", new { categoryId = product.CategoryId});
        }

        public async Task<IActionResult> Bascket()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var usersProducts = db.BasketProducts
                .Include(p=>p.Product)
                .Include(p => p.Product.Image)
                .Where(p => p.UserId == user.Id).ToList();

            return View(usersProducts);
        }

        public async Task<IActionResult> DeleteConfirmed(int productId)
        {
	        var user = await _userManager.GetUserAsync(HttpContext.User);
			var basketProduct = await db.BasketProducts
				.Include(p => p.Product)
				.Include(p => p.ApplicationUser)
				.FirstOrDefaultAsync(p => p.UserId == user.Id && p.ProductId == productId);
	        if (basketProduct is null)
	        {
		        return NotFound();
	        }

	        db.BasketProducts.Remove(basketProduct);
	        await db.SaveChangesAsync();

	        return RedirectToAction(nameof(Bascket));
        }
		//public async Task<IActionResult> Basket()
		//{
		//    var userId = await _userManager.FindByNameAsync(User.Identity.Name);

		//}

	}
}
