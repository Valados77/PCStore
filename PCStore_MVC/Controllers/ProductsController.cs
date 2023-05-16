using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PCStore_MVC.Data;
using PCStore_MVC.Models;
using PCStore_MVC.Models.ModelDB;
using System.Data;

namespace PCStore_MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Category).Include(p => p.Producer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Producer)
                .Include(p => p.Image)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
		}

		// GET: Products/Create
		[Route("CreateProduct")]
		[Authorize(Roles = "Administrators")]
		public IActionResult Create()
        {      
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("CreateProduct")]
        [Authorize(Roles = "Administrators")]
		public async Task<IActionResult> Create(ProductCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var image = await CreateImageAsync(model.File);
            var category = await _context.Categories.FindAsync(model.CategoryId);
            var producer = await _context.Producers.FindAsync(model.ProducerId);

            var product = new Product()
            {
                ProductName = model.ProductName,
                Producer = producer,
                Category = category,
                Description = model.Description,
                UnitPrice = model.UnitPrice,
                Image = image,
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

		[Authorize(Roles = "Administrators")]
		private async Task<Image> CreateImageAsync(IFormFile file)
        {
            var image = new Image();
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "Products");
            Directory.CreateDirectory(path);

            image.ImageTitle = Guid.NewGuid().ToString();
            image.Format = file.FileName.Split('.').Last();

            using var fs = new FileStream(Path.Combine(path, image.Name), FileMode.Create);
            using var fileStream = file.OpenReadStream();
            await fileStream.CopyToAsync(fs);

            return image;
        }

		// GET: Products/Edit/5
		[Route("EditProduct")]
		[Authorize(Roles = "Administrators")]
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
            ViewData["ProducerId"] = new SelectList(_context.Producers, "ProducerId", "ProducerId", product.ProducerId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("EditProduct")]
        [Authorize(Roles = "Administrators")]
		public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProducerId,CategoryId,Description,UnitPrice")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
            ViewData["ProducerId"] = new SelectList(_context.Producers, "ProducerId", "ProducerId", product.ProducerId);
            return View(product);
        }

		// GET: Products/Delete/5
		[Route("DeleteProduct")]
		[Authorize(Roles = "Administrators")]
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Producer)
                .Include(p => p.Image)
                .FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("DeleteProduct")]
        [Authorize(Roles = "Administrators")]
		public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.Include(p => p.Image).FirstOrDefaultAsync(p => p.ProductId == id);
            if(product is null)
            {
                return NotFound();
            }

            DeleteImage(product.Image);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

		[Authorize(Roles = "Administrators")]
		private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }

		[Authorize(Roles = "Administrators")]
		private void DeleteImage(Image image)
        {
            _context.Images.Remove(image);

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "Products", image.Name);
            System.IO.File.Delete(path);
        }
    }
}
